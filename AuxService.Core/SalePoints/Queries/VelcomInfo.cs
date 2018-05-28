using System.Runtime.Serialization;

using Sef.Utility.Common;

namespace AuxService.Core.SalePoints.Queries
{
  /// <summary>
  /// Траффик.
  /// </summary>
  [DataContract]
  public class VelcomInfo
  {
    #region Свойства

    /// <summary>
    /// Имя параметра.
    /// </summary>
    [DataMember]
    public string Parameter
    { get; set; }

    /// <summary>
    /// Значение.
    /// </summary>
    [DataMember]
    public long Value
    { get; set; }

    /// <summary>
    /// Значение для вывода.
    /// </summary>
    [IgnoreDataMember]
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
}
