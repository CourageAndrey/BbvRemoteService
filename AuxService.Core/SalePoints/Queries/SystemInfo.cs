using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Serialization;
using AuxService.Core.Helpers;
using Sef.Utility.Common;

namespace AuxService.Core.SalePoints.Queries
{
  /// <summary>
  /// Информация о системе.
  /// </summary>
  public sealed class SystemInfo
  {
    #region Properties

    /// <summary>
    /// Процессор.
    /// </summary>
    [XmlElement]
    public CPU Processor
    { get; set; }

    /// <summary>
    /// Память.
    /// </summary>
    [XmlAttribute]
    public uint Memory
    { get; set; }

    /// <summary>
    /// Материнская плата.
    /// </summary>
    [XmlElement]
    public MotherBoard MotherBoard
    { get; set; }

    /// <summary>
    /// Список жёстких дисков.
    /// </summary>
    [XmlArray("Disks")]
    [XmlArrayItem("Disk")]
    public List<Disk> HDD
    { get; set; }

    /// <summary>
    /// Список принтеров.
    /// </summary>
    [XmlArray("Printers")]
    [XmlArrayItem("Printer")]
    public List<Printer> Printers
    { get; set; }

    /// <summary>
    /// Список IP-адресов.
    /// </summary>
    [XmlArray("IPAddresses")]
    [XmlArrayItem("Address")]
    public List<string> IPAddresses
    { get; set; }

    /// <summary>
    /// Имя компьютера.
    /// </summary>
    [XmlAttribute]
    public string HostName
    { get; set; }

    /// <summary>
    /// Им пользователя.
    /// </summary>
    [XmlAttribute]
    public string UserName
    { get; set; }

    #region Display only

    /// <summary>
    /// Размер памяти.
    /// </summary>
    [XmlIgnore]
    public string MemorySize
    { get { return FileSystemHelper.FormatSize(Memory); } }

    /// <summary>
    /// Имя процессора.
    /// </summary>
    [XmlIgnore]
    public string ProcessorName
    { get { return Processor.Name; } }

    /// <summary>
    /// Скорость процессора.
    /// </summary>
    [XmlIgnore]
    public string ProcessorSpeed
    { get { return Processor.SpeedMHz.ToString("N0") + " МГц"; } }

    /// <summary>
    /// Производитель мат. платы.
    /// </summary>
    [XmlIgnore]
    public string MotherManufacturer
    { get { return MotherBoard.Manufacturer; } }

    /// <summary>
    /// Модель мат. платы.
    /// </summary>
    [XmlIgnore]
    public string MotherModel
    { get { return MotherBoard.Model; } }

    #endregion

    #endregion

    #region Конструкторы

    /// <summary>
    /// empty ctor.
    /// </summary>
    /// <remarks>инициализация пустой</remarks>
    public SystemInfo()
    {
      HDD = new List<Disk>();
      Printers = new List<Printer>();
      IPAddresses = new List<string>();
    }
    
    /// <summary>
    /// Получение информации о системе.
    /// </summary>
    /// <returns>SystemInfo</returns>
    /// <remarks>работает медленно, т.к. использует WMI</remarks>
    public static SystemInfo Request()
    {
      var info = new SystemInfo();

      try
      {
        var cpu = WmiHelper.First(WmiHelper.QueryInfo("Win32_Processor"));
        info.Processor = new CPU
        {
          Name = (string)cpu["Name"],
          SpeedMHz = (uint)cpu["CurrentClockSpeed"]
        };

        var memory = WmiHelper.First(WmiHelper.QueryInfo("Win32_LogicalMemoryConfiguration"));
        info.Memory = (uint)memory["TotalPhysicalMemory"]*1024;

        var motherboard = WmiHelper.First(WmiHelper.QueryInfo("Win32_BaseBoard"));
        info.MotherBoard = new MotherBoard
        {
          Manufacturer = (string)motherboard["Manufacturer"],
          Model = (string)motherboard["Product"]
        };

        foreach (var disk in Environment.GetLogicalDrives())
        {
          var drive = new DriveInfo(disk);
          if (drive.IsReady)
            info.HDD.Add(new Disk
            {
              Name = drive.Name,
              Label = drive.VolumeLabel,
              TotalSpace = drive.TotalSize,
              FreeSpace = drive.AvailableFreeSpace
            });
        }

        info.Printers.AddRange(PrintInfo.GetPrinterList());
        foreach (var printer in WmiHelper.QueryInfo("Win32_Printer"))
        {
          string name = (string) printer.Properties["Caption"].Value;
          var printerInfo = info.Printers.Find(p => p.Caption == name);
          if (printerInfo != null)
            printerInfo.Model = (string)printer.Properties["DriverName"].Value;
        }

        info.HostName = SystemInformation.ComputerName;

        foreach (var address in Dns.GetHostEntry(info.HostName).AddressList)
          info.IPAddresses.Add(address.ToString());

        info.UserName = SystemInformation.UserName; // можно также через System.Enironment.UserName
      }
      catch
      { }

      return info;
    }

    #endregion
  }

  #region Вспомогательные классы

  /// <summary>
  /// Процессор.
  /// </summary>
  public class CPU
  {
    /// <summary>
    /// Название.
    /// </summary>
    [XmlAttribute]
    public string Name
    { get; set; }

    /// <summary>
    /// Частота в МГц.
    /// </summary>
    [XmlAttribute]
    public uint SpeedMHz
    { get; set; }
  }

  /// <summary>
  /// Материнская плата.
  /// </summary>
  public class MotherBoard
  {
    /// <summary>
    /// Производитель.
    /// </summary>
    [XmlAttribute]
    public string Manufacturer
    { get; set; }

    /// <summary>
    /// Модель.
    /// </summary>
    [XmlAttribute]
    public string Model
    { get; set; }
  }

  /// <summary>
  /// Диск.
  /// </summary>
  public class Disk
  {
    /// <summary>
    /// Буква.
    /// </summary>
    [XmlAttribute]
    public string Name
    { get; set; }

    /// <summary>
    /// Метка.
    /// </summary>
    [XmlAttribute]
    public string Label
    { get; set; }

    /// <summary>
    /// Всего места.
    /// </summary>
    [XmlAttribute]
    public long TotalSpace
    { get; set; }

    /// <summary>
    /// Свободное места.
    /// </summary>
    [XmlAttribute]
    public long FreeSpace
    { get; set; }

    /// <summary>
    /// Всего места (формат).
    /// </summary>
    [XmlIgnore]
    public string TotalSpaceFormatted
    { get { return FileSystemHelper.FormatSize(TotalSpace); } }

    /// <summary>
    /// Свободное места (формат).
    /// </summary>
    [XmlIgnore]
    public string FreeSpaceFormatted
    { get { return FileSystemHelper.FormatSize(FreeSpace); } }
  }

  /// <summary>
  /// Принтер.
  /// </summary>
  public class Printer
  {
    /// <summary>
    /// Имя в системе.
    /// </summary>
    [XmlAttribute]
    public string Caption
    { get; set; }

    /// <summary>
    /// Модель.
    /// </summary>
    [XmlAttribute]
    public string Model
    { get; set; }

    /// <summary>
    /// Установлен по умолчанию.
    /// </summary>
    [XmlAttribute]
    public bool Default
    { get; set; }
  }

  #endregion
}
