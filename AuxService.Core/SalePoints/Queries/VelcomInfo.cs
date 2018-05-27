using System.Collections.Generic;
using System.Xml.Serialization;
using AuxService.Core.Helpers;
using Sef.Utility.Common;

namespace AuxService.Core.SalePoints.Queries
{
  /// <summary>
  /// Траффик.
  /// </summary>
  public class VelcomInfo
  {
    #region Свойства

    /// <summary>
    /// Имя параметра.
    /// </summary>
    [XmlAttribute]
    public string Parameter
    { get; set; }

    /// <summary>
    /// Значение.
    /// </summary>
    [XmlAttribute]
    public long Value
    { get; set; }

    /// <summary>
    /// Значение для вывода.
    /// </summary>
    [XmlIgnore]
    public string ValueFormatted
    { get { return FileSystemHelper.FormatSize(Value); } }

    #endregion

    #region Конструкторы

    /// <summary>
    /// xml ctor.
    /// </summary>
    public VelcomInfo()
    { }

    /// <summary>
    /// ctor.
    /// </summary>
    /// <param name="parameter">свойство</param>
    /// <param name="value">значение</param>
    public VelcomInfo(string parameter, long value)
    {
      Parameter = parameter;
      Value = value;
    }

    #endregion
  }

  /// <summary>
  /// Полная информация о состоянии ПР.
  /// </summary>
  public class VelcomInfoList
  {
    #region Свойства

    /// <summary>
    /// Состояния.
    /// </summary>
    [XmlArray("Parameters")]
    [XmlArrayItem("Parameter")]
    public List<VelcomInfo> Parameters
    { get; set; }

    #endregion

    /// <summary>
    /// Запрос информации.
    /// </summary>
    /// <returns>состояние</returns>
    public static VelcomInfoList Request()
    {
      var velcom = VelcomHelper.Request();
      
      var result = new VelcomInfoList();
      result.Parameters = new List<VelcomInfo>
      {
        new VelcomInfo("Получено за день", velcom.DayDownloaded),
        new VelcomInfo("Отправлено за день", velcom.DayUploaded),
        new VelcomInfo("Получено за неделю", velcom.WeekDownloaded),
        new VelcomInfo("Отправлено за неделю", velcom.WeekUploaded),
        new VelcomInfo("Получено за месяц", velcom.MonthDownloaded),
        new VelcomInfo("Отправлено за месяц", velcom.MonthUploaded),
        new VelcomInfo("Получено за год", velcom.YearDownloaded),
        new VelcomInfo("Отправлено за год", velcom.YearUploaded)
      };
      return result;
    }
  }
}
