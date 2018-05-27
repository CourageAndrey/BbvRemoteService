using System;
using System.Collections.Generic;
using System.IO;
using System.Timers;
using AuxService.Core.Helpers;
using AuxService.Core.Service;
using AuxService.Core.Settings;
using ICSharpCode.SharpZipLib.Zip;
using Sef.Utility.Database;
using Sef.Utility.Log;
using Sef.Utility.Common;

namespace AuxService.ClientService
{
  internal partial class ClientService
  {
    private void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
      // корректное переименование текущего потока
      OsHelper.RenameCurrentThread(Constants.ThreadClient);

      // получение временной папки для файлов
      var outputDirectory = Directory.CreateDirectory(Path.Combine(Path.GetTempPath(), "___AUX TMP___"));

      // оптимизация и сохранение копий
      foreach (var dbWrapper in Config.Instance.Databases)
      {
        if (dbWrapper.Optimize)
          execute(() => DatabaseHelper.Instance.OptimizeDatabase(dbWrapper.Database, true), string.Format("оптимизация бд {0}", dbWrapper.Database));
        execute(() => DatabaseHelper.Instance.BackupDatabase(dbWrapper.Database, outputDirectory.FullName, false), string.Format("сохранение бд {0}", dbWrapper.Database));
      }

      // сжатие копий баз в файл на диске
      var tempFileName = Path.GetTempFileName();
      tempFileName = Path.ChangeExtension(tempFileName, ".zip");
      execute(() => zip(outputDirectory, tempFileName), "сохранение копий баз в архив");

      // запись в журнал размера архива
      long size = new FileInfo(tempFileName).Length;
      LogHelper.Write(logMain,
        MessageType.Successfull,
        string.Format("Создан архив объемом {0}.", FileSystemHelper.FormatSize(size)));

      // удаление временных файлов
      outputDirectory.Delete(true);

      // сохранение архива на флешку
      new FileInfo(tempFileName).MoveTo(Path.Combine(Config.Instance.OutputPath, OsHelper.GetDateString(DateTime.Now) + ".zip"));

      // удаление старых архивов с флешки
      deleteOld(size);

      // повторный запуск таймера
      setupTimer(sender as Timer);
    }

    private static void deleteOld(long size)
    {
      var outDirectory = new DirectoryInfo(Config.Instance.OutputPath);
      var possibleDeletedFiles = new List<FileInfo>(outDirectory.GetFiles("*.zip"));
      possibleDeletedFiles.Sort((f1, f2) => f1.CreationTime.CompareTo(f2.CreationTime));
      var disk = new DriveInfo(outDirectory.Root.FullName);
      while (disk.AvailableFreeSpace < size * 3)
        if (possibleDeletedFiles.Count > 2) // Хранить минимум 2 последних
        {
          var deletedFile = possibleDeletedFiles[0];
          possibleDeletedFiles.Remove(deletedFile);
          deletedFile.Delete();
        }
        else
          break;
    }

    private void execute(Action action, string description)
    {
      try
      {
        LogHelper.Write(logMain, MessageType.Start, string.Format("Запускается: {0}...", description));
        action.Invoke();
        LogHelper.Write(logMain, MessageType.Stop, string.Format("Завершено: {0}...", description));
      }
      catch (Exception ex)
      {
        LogHelper.Write(logMain, MessageType.Error, "Во время выполнения произошла ошибка...", ex);
      }
    }

    private static DateTime getNextStart(DateTime hhmm)
    {
      int h = hhmm.Hour;
      int m = hhmm.Minute;
      var now = DateTime.Now;
      if ((now.Hour > h) || (now.Hour == h && now.Minute > m))
        now = now.AddDays(1);
      return now.Date.AddHours(h).AddMinutes(m);
    }

    private static void setupTimer(Timer timer)
    {
      double interval = (getNextStart(Config.Instance.ScheduleTime) - DateTime.Now).TotalMilliseconds;
      timer.Interval = interval;
      timer.Enabled = true;
    }

    private static void zip(DirectoryInfo directory, string fileName)
    {
      using (var archive = ZipFile.Create(fileName))
      {
        archive.BeginUpdate();
        foreach (var file in directory.GetFiles())
          archive.Add(file.FullName);
        archive.CommitUpdate();
      }
    }
  }
}
