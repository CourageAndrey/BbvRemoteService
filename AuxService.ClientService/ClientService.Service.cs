using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using AuxService.Core.Helpers;
using AuxService.Core.Service;
using AuxService.Core.Settings;
using AuxService.Core.Transfer;
using Microsoft.Win32;
using Sef.Utility.Applications;
using Sef.Utility.Database;
using Sef.Utility.Log;
using log4net;
using log4net.Config;

namespace AuxService.ClientService
{
  /// <summary>
  /// Служба клиента.
  /// </summary>
  internal partial class ClientService : ServiceExt<ClientService>
  {
    /// <summary>
    /// Корректная точка входа.
    /// </summary>
    /// <param name="args">параметры</param>
    public static void Main(string[] args)
    {
      MainBase(args);
    }

    /// <summary>
    /// ctor.
    /// </summary>
    public ClientService()
    {
      ServiceName = Constants.ClientServiceDisplayName;
      Directory.SetCurrentDirectory(Application.StartupPath);
      OsHelper.RenameCurrentThread(Constants.ThreadClient);
      XmlConfigurator.Configure(new FileInfo(Path.Combine(Application.StartupPath, "LoggerConfig.xml")));
      logMain = LogManager.GetLogger(Constants.LogService);
      logSpooler = LogManager.GetLogger(Constants.LogSpooler);
    }

    /// <summary>
    /// Основной код службы.
    /// </summary>
    protected override void AgentMain()
    {
      try
      {
        // инициализация
        OsHelper.RenameCurrentThread(Constants.ThreadClient);
        LogHelper.Write(logMain, MessageType.Start, "Запуск службы...");
        Config.LoadOrCreate();
        LogHelper.Write(logMain, MessageType.Information, "Прочитаны настройки...");

        // запуск таймера для обработки БД
        var timer = new System.Timers.Timer { AutoReset = false };
        timer.Elapsed += timer_Elapsed;
        setupTimer(timer);
        if (ConsoleRunInvoked)
          LogHelper.Write(logMain, MessageType.Debug, string.Format("Запущен таймер, сработает через ~{0:N0} секунд...", timer.Interval/1000));

        // ожидание запросов от сервера
        var server = new Server();
        server.Receive += server_Receive;
        if (ConsoleRunInvoked)
          LogHelper.Write(logMain, MessageType.Debug, "Запущено ожидание запросов от сервера...");

        // запуск проверки очереди печати
        spoolerWatchdog = new Thread(spoolerDelegate);
        spoolerWatchdog.Start();
        if (ConsoleRunInvoked)
          LogHelper.Write(logMain, MessageType.Debug, "Запущен поток слежения за принтером...");

        // отслеживание смены времени
        SystemEvents.TimeChanged += timeChanged;
        if (ConsoleRunInvoked)
          LogHelper.Write(logMain, MessageType.Debug, "Включено слежение за изменением времени...");
      }
      catch (Exception ex)
      {
        if (ConsoleRunInvoked)
        {
          LogHelper.Write(logMain, MessageType.Fatal, "Произошла ошибка!", ex);
          Thread.Sleep(50);
        }
        throw;
      }
    }

    /// <summary>
    /// When implemented in a derived class, executes when a Stop command is sent to the service by the Service Control Manager (SCM). Specifies actions to take when a service stops running.
    /// </summary>
    protected override void OnStop()
    {
      base.OnStop();

      // остановка чтения очереди принтера
      spoolerWatchdog.Abort();

      // запись в журнал
      OsHelper.RenameCurrentThread(Constants.ThreadClient);
      LogHelper.Write(logMain, MessageType.Stop, "Остановка службы...");
    }

    // основной журнал работы
    private readonly ILog logMain;
    // журнал работы принтера
    private readonly ILog logSpooler;

    // было изменено системное время
    private void timeChanged(object sender, EventArgs e)
    {
      LogHelper.Write(logMain, MessageType.Warning, "Было изменено системное время!");
    }
  }
}