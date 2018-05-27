using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Printing;
using System.Windows.Forms;
using System.Xml.Serialization;
using Sef.Utility.Common;
using Sef.Utility.Xml;

namespace AuxService.Core.SalePoints.Queries
{
  /// <summary>
  /// Запись очереди печати.
  /// </summary>
  public class PrintInfo
  {
    #region Свойства

    /// <summary>
    /// JobSize.
    /// </summary>
    [XmlAttribute]
    public int Size
    { get; set; }

    /// <summary>
    /// Name.
    /// </summary>
    [XmlAttribute]
    public string Name
    { get; set; }

    /// <summary>
    /// NumberOfPages.
    /// </summary>
    [XmlAttribute]
    public int NumberOfPages
    { get; set; }

    /// <summary>
    /// Время снимка.
    /// </summary>
    [XmlAttribute]
    public DateTime TimeStamp
    { get; set; }

    /// <summary>
    /// JobIdentifier.
    /// </summary>
    [XmlAttribute]
    public int Id
    { get; set; }

    /// <summary>
    /// Задача сохранена.
    /// </summary>
    [XmlIgnore]
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

  /// <summary>
  /// Полная информация о очереди печати.
  /// </summary>
  public class PrintInfoList
  {
    #region Свойства

    /// <summary>
    /// Состояния.
    /// </summary>
    [XmlArray("Jobs")]
    [XmlArrayItem("PrintJob")]
    public List<PrintInfo> Spooler
    { get; set; }

    #endregion

    /// <summary>
    /// Запрос информации.
    /// </summary>
    /// <returns>состояние</returns>
    public static PrintInfoList Request()
    {
      var result = new PrintInfoList { Spooler = new List<PrintInfo>() };
      var spooler = new DirectoryInfo(Path.Combine(Application.StartupPath, "Spooler"));

      foreach (var file in spooler.GetFileSystemInfos("*.log*"))
      {
        var text = File.ReadAllText(file.FullName, FileSystemHelper.GetFileEncoding(file.FullName));
        var lines = text.Split(separator);
        foreach (var line in lines)
          if (!string.IsNullOrEmpty(line.Trim()))
            result.Spooler.Add(XmlHelper.DeserializeXml<PrintInfo>(line));
      }

      return result;
    }
    
    // разделитель строк
    private const char separator = '·';
  }
}
