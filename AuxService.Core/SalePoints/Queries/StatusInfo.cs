using System.Collections.Generic;
using System.Xml.Serialization;
using AuxService.Core.Settings;
using AuxService.Core.Service;

namespace AuxService.Core.SalePoints.Queries
{
  /// <summary>
  /// Состояние ПР.
  /// </summary>
  public class StatusInfo
  {
    #region Свойства

    /// <summary>
    /// Свойство.
    /// </summary>
    [XmlAttribute]
    public string Parameter
    { get; set; }

    /// <summary>
    /// Значение.
    /// </summary>
    [XmlAttribute]
    public string Status
    { get; set; }

    /// <summary>
    /// Корректно.
    /// </summary>
    [XmlAttribute]
    public bool Valid
    { get; set; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// xml ctor.
    /// </summary>
    public StatusInfo()
    { }

    /// <summary>
    /// ctor.
    /// </summary>
    /// <param name="parameter">свойство</param>
    /// <param name="status">значение</param>
    /// <param name="valid">корректно</param>
    public StatusInfo(string parameter, string status, bool valid)
    {
      Parameter = parameter;
      Status = status;
      Valid = valid;
    }

    #endregion
  }

  /// <summary>
  /// Полная информация о состоянии ПР.
  /// </summary>
  public class StatusInfoList
  {
    #region Свойства

    /// <summary>
    /// Состояния.
    /// </summary>
    [XmlArray("Statuses")]
    [XmlArrayItem("Status")]
    public List<StatusInfo> Statuses
    { get; set; }

    #endregion

    /// <summary>
    /// Запрос информации.
    /// </summary>
    /// <returns>состояние</returns>
    public static StatusInfoList Request()
    {
      var result = new StatusInfoList { Statuses = new List<StatusInfo>() };
      foreach (var serviceName in Config.Instance.ControlledServices)
      {
        var service = new ServiceRecord(serviceName);
        result.Statuses.Add(new StatusInfo(service.ServiceName, service.StatusString, service.IsInstalled && !service.IsStopped));
      }

      return result;
    }
  }
}
