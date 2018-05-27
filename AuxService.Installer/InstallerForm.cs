using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AuxService.Core.Service;
using AuxService.Core.Settings;
using AuxService.Core.Transfer;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using Sef.Utility.Common;
using Sef.Utility.Database;

namespace AuxService.Installer
{
  /// <summary>
  /// Главная форма инсталлятора.
  /// </summary>
  public partial class InstallerForm : XtraForm
  {
    #region Инициализация

    /// <summary>
    /// ctor.
    /// </summary>
    public InstallerForm()
    {
      InitializeComponent();
    }

    private List<ServiceRecord> services;
    private DirectoryInfo programDirectory;
    private bool hasLog, hasSpooler, sqlServerPresent, driveFound;

    #endregion

    #region Установка

    private void prepareToInstall()
    {
      // получение списка задействованных служб
      services = ServiceRecord.GetList();
      sqlServerPresent = services.Find(s => s.ServiceName == Constants.ServiceSql) != null;
      log(sqlServerPresent
            ? "Найден установленный SQL-сервер. Настройки по умолчанию будут созданы для главного компьютера."
            : "SQL-сервер не обнаружен. Настройки по умолчанию будут созданы для второго компьютера.");
      services.RemoveAll(s => !s.DisplayName.Contains("BlankPublish Auxiliary Service"));
      foreach (var service in services)
        log(string.Format(
          "Найдена служба \"{0}\", состояние: {1}.",
          service.DisplayName,
          service.IsStopped ? "остановлена" : "запущена"));

      // поиск предыдущей версии программы
      programDirectory = new DirectoryInfo(Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles),
        "AuxService"));
      log("Папка установки: " + programDirectory.FullName);
      if (programDirectory.Exists)
      {
        log("Эта папка существует.");
        string oldFile = Path.Combine(programDirectory.FullName, "AuxService.Core.dll");
        if (File.Exists(oldFile))
        {
          var version = FileVersionInfo.GetVersionInfo(oldFile);
          log("Обнаружена установленная ранее версия - " + version.FileVersion);
        }
      }
      else
        log("Эта папка не существует и будет создана заново.");

      // создание настроек по умолчанию
      Config.LoadOrCreate();
      log("Созданы настройки по умолчанию.");
      
      if (sqlServerPresent)
      {
        // подготовка
        var serverBases = DatabaseHelper.Instance.GetDatabaseList("(local)");
        var databases = Config.Instance.Databases.Select(database => database.Database).ToList();

        // поиск базы АИС УРТ
        var aisurtConfig = Config.Instance.Databases.Find(db => isAisurt(db.Database.Database));
        int aisurt = serverBases.FindIndex(isAisurt);
        if (aisurt >= 0)
        {
          string name = serverBases[aisurt];
          aisurtConfig.Database.Database = name;
          log("БД АИС УРТ обнаружена, имя - " + name);
        }
        else
        {
          databases.Remove(aisurtConfig.Database);
          Config.Instance.Databases.Remove(aisurtConfig);
          log("БД АИС УРТ не найдена!");
        }

        // исключение из списка лишних баз данных
        foreach (var database in databases)
        {
          string dbName = database.Database;
          if (!serverBases.Contains(dbName))
          {
            Config.Instance.Databases.RemoveAll(db => db.Database.Database == dbName);
            log(string.Format("БД \"{0}\" не найдена!", dbName));
          }
        }
      }
      else
      {
        Config.Instance.Databases.Clear();
        Config.Instance.OutputPath = "C:\\";
        Config.Instance.ScheduleTime = DateTime.Now.Date;
      }
      log("Окончена предварительная настройка.");

      // удаление лишних сервисов
      var serviceList = Config.Instance.ControlledServices.Where(service => !new ServiceRecord(service).IsInstalled).ToList();
      foreach (var service in serviceList)
        if (service != Constants.ClientServiceName || service != Constants.ClientServiceDisplayName)
        {
          log(string.Format("Служба \"{0}\" не найдена!", service));
          Config.Instance.ControlledServices.Remove(service);
        }

      // поиск флешки
      var drives = Directory.GetLogicalDrives();
      foreach (var drive in drives)
      {
        var info = new DriveInfo(drive);
        if (info.IsReady && (info.DriveType == DriveType.Removable) && (info.VolumeLabel.ToLower() == "transcend"))
        {
          Config.Instance.OutputPath = drive;
          driveFound = true;
          break;
        }
      }
      log(driveFound
        ? "Обнаружена USB-флешка, путь " + Config.Instance.OutputPath
        : "Флешка для сохранения бэкапов не найдена." + (sqlServerPresent ? "Установите вручную" : string.Empty));

      // сохранение настроек
      Config.Save();

      // включение кнопки "Инсталл"
      log(null);
    }

    private void install()
    {
      // остановка служб
      var sbuilder = new StringBuilder();
      sbuilder.AppendLine("Пожалуйста, вручную отключите запуск следующих служб:");
      int toUninstall = 0;
      foreach (var service in services)
      {
        if (!service.DisplayName.Contains("part"))
        {
          toUninstall++;
          sbuilder.AppendLine("* " + service.DisplayName);
        }
        if (service.IsInstalled && !service.IsStopped)
        {
          service.Stop(null);
          log("Остановлена служба: " + service.DisplayName);
        }
      }

      // ожидание завершения службы
      string library = Path.Combine(programDirectory.FullName, "AuxService.Core.dll");
      if (File.Exists(library))
        try
        {
          FileSystemHelper.WaitFile(library);
          Thread.Sleep(100);
        }
        catch
        {
          Thread.Sleep(1000);
        }
      Thread.Sleep(2000);

      // создание либо очистка папки);
      if (programDirectory.Exists)
      {
        foreach (var file in programDirectory.GetFiles())
          file.Delete();

        // условие нужно для сохранения в целостности
        // журнала работы и принтера
        foreach (var directory in programDirectory.GetDirectories())
          if (directory.Name == "Log")
            hasLog = true;
          else if (directory.Name == "Spooler")
            hasSpooler = true;
          else
            directory.Delete(true);

        log("Очищена папка программы.");
      }
      else
      {
        programDirectory.Create();
        log("Создана папка программы.");
      }

      // копирование файлов
      var currentDir = new DirectoryInfo(Application.StartupPath);
      using (new AutoWaitCursor())
      {
        // файлы - простое копирование
        foreach (var file in currentDir.GetFiles())
          if (file.Name != "AuxService.Installer.exe")
            file.CopyTo(Path.Combine(programDirectory.FullName, file.Name), true);
        // папки - с сохранением лога и спулера
        foreach (var directory in currentDir.GetDirectories())
          if (!(directory.Name == "Spooler" && hasSpooler) && !(directory.Name == "Log" && hasLog))
          {
            var outPath = Path.Combine(programDirectory.FullName, directory.Name);
            Directory.CreateDirectory(outPath);
            foreach (var file in directory.GetFiles())
              file.CopyTo(Path.Combine(outPath, file.Name), true);
          }
      }
      log("Скопированы файлы программы.");

      // регистрация службы
      if (services.Find(s => s.DisplayName == Constants.ClientServiceDisplayName) == null)
      {
        var installer = new FileInfo(Path.Combine(
          Environment.GetFolderPath(Environment.SpecialFolder.Windows),
          @"Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe"));
        FileSystemHelper.Execute(
          installer.FullName,
          string.Format("\"{0}\"", Path.Combine(programDirectory.FullName, "AuxService.ClientService.exe")), true);
        log("Зарегистрирована служба клиента.");
      }

      // открытие портов файервола
      const int port = Protocol.ConnectionPort;
      FileSystemHelper.Execute(
        @"netsh",
        string.Format(@"firewall add portopening TCP {0} AuxServiceRule Enable All", port), true);
      log(string.Format("Настроен брандмауэр Windows - открыт порт №{0}.", port));

      // создание проверки сделанных бэкапов (добавление программы контроля в автозапуск)
      if (Config.Instance.Databases.Count > 0)
      {
        using (var autorun = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
          autorun.SetValue(
            "AuxService",
            Path.Combine(programDirectory.FullName, "AuxService.BackupChecker.exe"),
            RegistryValueKind.String);
        log("В автозагрузку добавлена проверка сделанных копий баз.");
      }

      // создание пустого zip-архива на флешке (для обмана контроля при первом запуске)
      if (new DirectoryInfo(Config.Instance.OutputPath).Exists)
        using (File.Create(Path.Combine(Config.Instance.OutputPath, "backup_void.zip")))
        { }

      // предупреждения в конце
      log("###################");
      log("# УСТАНОВКА ЗАВЕРШЕНА #");
      log("###################");
      if (toUninstall > 0)
        log(sbuilder.ToString());
      if (Config.Instance.Databases.Count > 0)
        log("Если в MS SQL Server настроены job-ы для архивирования баз, отключите их вручную!");
      log("Проверьте вручную, чтобы запуск старых служб был отключён, а служба AUX-клиента запускалась от имени текущего пользователя.");
      log("На данном компьютере в настоящий момент работает пользователь: " + SystemInformation.UserName);
      if (!driveFound && sqlServerPresent)
        log("Необходимо корректно настроить путь к выходной папке!");
      log("Убедившись предварительно, что всё настроено правильно, запустите службу клиента из конфигуратора клиента.");
    }

    #endregion

    #region Обработчики кнопок

    private void simpleButtonPrepare_Click(object sender, EventArgs e)
    {
      simpleButtonPrepare.Enabled = false;
      var thread = new Thread(prepareToInstall);
      using (new AutoWaitCursor())
        thread.Start();
    }

    private void simpleButtonInstall_Click(object sender, EventArgs e)
    {
      simpleButtonInstall.Enabled = false;
      using (new AutoWaitCursor())
        new Thread(install).Start();
    }

    #endregion

    #region Запись в лог

    private void log(string message)
    {
      new Thread(() => Invoke(new WriteLog(writeLog), message)).Start();
      Thread.Sleep(1);
    }

    private delegate void WriteLog(string message);

    private void writeLog(string message)
    {
      if (!string.IsNullOrEmpty(message))
      {
        listBoxControlLog.Items.Add(message);
        listBoxControlLog.SelectedIndex = listBoxControlLog.Items.Count - 1;
      }
      else
        simpleButtonInstall.Enabled = true;
    }

    #endregion

    private static bool isAisurt(string database)
    {
      return database.ToLower().Contains("aisurt");
    }
  }
}