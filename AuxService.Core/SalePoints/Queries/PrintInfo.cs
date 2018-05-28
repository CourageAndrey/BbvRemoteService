using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Printing;
using System.Runtime.Serialization;

namespace AuxService.Core.SalePoints.Queries
{
  /// <summary>
  /// Запись очереди печати.
  /// </summary>
  [DataContract]
  public class PrintInfo
  {
    #region Свойства

    /// <summary>
    /// JobSize.
    /// </summary>
    [DataMember]
    public int Size
    { get; set; }

    /// <summary>
    /// Name.
    /// </summary>
    [DataMember]
    public string Name
    { get; set; }

    /// <summary>
    /// NumberOfPages.
    /// </summary>
    [DataMember]
    public int NumberOfPages
    { get; set; }

    /// <summary>
    /// Время снимка.
    /// </summary>
    [DataMember]
    public DateTime TimeStamp
    { get; set; }

    /// <summary>
    /// JobIdentifier.
    /// </summary>
    [DataMember]
    public int Id
    { get; set; }

    /// <summary>
    /// Задача сохранена.
    /// </summary>
    [IgnoreDataMember]
    public bool Stored
    { get; set; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// xml ctor.
    /// </summary>
    public PrintInfo()
    { }

    private PrintInfo(PrintSystemJobInfo info)
    {
      Size = info.JobSize;
      Name = info.Name;
      NumberOfPages = info.NumberOfPages;
      TimeStamp = DateTime.Now;
      Id = info.JobIdentifier;
    }

    #endregion

    #region Работа со списком

    /// <summary>
    /// Чтение состояния принтера.
    /// </summary>
    /// <returns>список текущих задач</returns>
    public static List<PrintInfo> Request()
    {
      var jobs = new List<PrintInfo>();

      try
      {
        var server = new LocalPrintServer();
        var queue = server.DefaultPrintQueue;
        if (queue != null)
          foreach (var job in queue.GetPrintJobInfoCollection())
            jobs.Add(new PrintInfo(job));
      }
      catch
      { }

      return jobs;
    }

    #endregion

    /// <summary>
    /// Получение полного списка.
    /// </summary>
    /// <returns>список принтеров</returns>
    public static List<Printer> GetPrinterList()
    {
      var list = new List<Printer>();
      foreach (string printerName in PrinterSettings.InstalledPrinters)
      {
        var printer = new PrinterSettings { PrinterName = printerName };
        if (printer.IsValid)
          list.Add(new Printer { Caption = printerName, Default = printer.IsDefaultPrinter });
      }
      return list;
    }
  }
}
