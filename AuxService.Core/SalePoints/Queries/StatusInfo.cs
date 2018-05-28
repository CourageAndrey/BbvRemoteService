using System.Runtime.Serialization;

namespace AuxService.Core.SalePoints.Queries
{
  /// <summary>
  /// Состояние ПР.
  /// </summary>
  [DataContract]
  public class StatusInfo
  {
    #region Свойства

    /// <summary>
    /// Свойство.
    /// </summary>
    [DataMember]
    public string Parameter
    { get; set; }

    /// <summary>
    /// Значение.
    /// </summary>
    [DataMember]
    public string Status
    { get; set; }

    /// <summary>
    /// Корректно.
    /// </summary>
    [DataMember]
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
}
