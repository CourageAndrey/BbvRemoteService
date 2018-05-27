using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AuxService.Core.Helpers;
using AuxService.Core.SalePoints.Queries;
using AuxService.Core.Service;
using AuxService.Core.Settings;
using Sef.Utility.Xml;

namespace AuxService.ClientService
{
	internal partial class ClientService
	{
    private Thread spoolerWatchdog;

	  private readonly List<PrintInfo> oldPrintJobs = new List<PrintInfo>();

    // опрос очереди печати по таймеру
    private void spoolerDelegate()
    {
      try
      {
        OsHelper.RenameCurrentThread(Constants.ThreadSpooler);
        while (true)
        {
          // запрос новых записей
          var printJobs = PrintInfo.Request();
          foreach (var pringJob in printJobs)
          {
            // поиск старой записи
            var old = oldPrintJobs.Find(job => job.Id == pringJob.Id);

            // если такой нету - заносим в список
            if (old == null)
              oldPrintJobs.Add(pringJob);
            // если есть - объединяем со старой
            else
            {
              old.TimeStamp = DateTime.Now;
              old.Size = Math.Max(old.Size, pringJob.Size);
              old.NumberOfPages = Math.Max(old.NumberOfPages, pringJob.NumberOfPages);
            }
          }

          // сохранение старых
          var toSave = oldPrintJobs.Where(job =>
            !job.Stored &&
            (DateTime.Now - job.TimeStamp).TotalSeconds > Config.SpoolerDelay);
          foreach (var info in toSave)
          {
            var xml = XmlHelper.SerializeElement(info);
            logSpooler.Info(xml.OuterXml);
            info.Stored = true;
          }

          // усыпление потока
          Thread.Sleep(Config.Instance.SpoolerTimer);
        }
      }
      catch (ThreadAbortException)
      { }
    }
	}
}
