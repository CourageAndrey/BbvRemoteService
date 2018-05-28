using System.Collections.Generic;
using System.Runtime.Serialization;

using Sef.Utility.Common;

namespace AuxService.Core.SalePoints.Queries
{
  /// <summary>
  /// Информация о системе.
  /// </summary>
  [DataContract]
  public sealed class SystemInfo
  {
    #region Properties

    /// <summary>
    /// Процессор.
    /// </summary>
    [DataMember]
    public CPU Processor
    { get; set; }

    /// <summary>
    /// Память.
    /// </summary>
    [DataMember]
    public uint Memory
    { get; set; }

    /// <summary>
    /// Материнская плата.
    /// </summary>
    [DataMember]
    public MotherBoard MotherBoard
    { get; set; }

    /// <summary>
    /// Список жёстких дисков.
    /// </summary>
    [DataMember]
    public List<Disk> HDD
    { get; set; }

    /// <summary>
    /// Список принтеров.
    /// </summary>
    [DataMember]
    public List<Printer> Printers
    { get; set; }

    /// <summary>
    /// Список IP-адресов.
    /// </summary>
    [DataMember]
    public List<string> IPAddresses
    { get; set; }

    /// <summary>
    /// Имя компьютера.
    /// </summary>
    [DataMember]
    public string HostName
    { get; set; }

    /// <summary>
    /// Им пользователя.
    /// </summary>
    [DataMember]
    public string UserName
    { get; set; }

    #region Display only

    /// <summary>
    /// Размер памяти.
    /// </summary>
    [IgnoreDataMember]
    public string MemorySize
    { get { return FileSystemHelper.FormatSize(Memory); } }

    /// <summary>
    /// Имя процессора.
    /// </summary>
    [IgnoreDataMember]
    public string ProcessorName
    { get { return Processor.Name; } }

    /// <summary>
    /// Скорость процессора.
    /// </summary>
    [IgnoreDataMember]
    public string ProcessorSpeed
    { get { return Processor.SpeedMHz.ToString("N0") + " МГц"; } }

    /// <summary>
    /// Производитель мат. платы.
    /// </summary>
    [IgnoreDataMember]
    public string MotherManufacturer
    { get { return MotherBoard.Manufacturer; } }

    /// <summary>
    /// Модель мат. платы.
    /// </summary>
    [IgnoreDataMember]
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

    #endregion
  }

  #region Вспомогательные классы

  /// <summary>
  /// Процессор.
  /// </summary>
  [DataContract]
  public class CPU
  {
    /// <summary>
    /// Название.
    /// </summary>
    [DataMember]
    public string Name
    { get; set; }

    /// <summary>
    /// Частота в МГц.
    /// </summary>
    [DataMember]
    public uint SpeedMHz
    { get; set; }
  }

  /// <summary>
  /// Материнская плата.
  /// </summary>
  [DataContract]
  public class MotherBoard
  {
    /// <summary>
    /// Производитель.
    /// </summary>
    [DataMember]
    public string Manufacturer
    { get; set; }

    /// <summary>
    /// Модель.
    /// </summary>
    [DataMember]
    public string Model
    { get; set; }
  }

  /// <summary>
  /// Диск.
  /// </summary>
  [DataContract]
  public class Disk
  {
    /// <summary>
    /// Буква.
    /// </summary>
    [DataMember]
    public string Name
    { get; set; }

    /// <summary>
    /// Метка.
    /// </summary>
    [DataMember]
    public string Label
    { get; set; }

    /// <summary>
    /// Всего места.
    /// </summary>
    [DataMember]
    public long TotalSpace
    { get; set; }

    /// <summary>
    /// Свободное места.
    /// </summary>
    [DataMember]
    public long FreeSpace
    { get; set; }

    /// <summary>
    /// Всего места (формат).
    /// </summary>
    [IgnoreDataMember]
    public string TotalSpaceFormatted
    { get { return FileSystemHelper.FormatSize(TotalSpace); } }

    /// <summary>
    /// Свободное места (формат).
    /// </summary>
    [IgnoreDataMember]
    public string FreeSpaceFormatted
    { get { return FileSystemHelper.FormatSize(FreeSpace); } }
  }

  /// <summary>
  /// Принтер.
  /// </summary>
  [DataContract]
  public class Printer
  {
    /// <summary>
    /// Имя в системе.
    /// </summary>
    [DataMember]
    public string Caption
    { get; set; }

    /// <summary>
    /// Модель.
    /// </summary>
    [DataMember]
    public string Model
    { get; set; }

    /// <summary>
    /// Установлен по умолчанию.
    /// </summary>
    [DataMember]
    public bool Default
    { get; set; }
  }

  #endregion
}
