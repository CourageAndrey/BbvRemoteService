using System.Runtime.Serialization;

namespace AuxService.Core.SalePoints.Queries
{
  /// <summary>
  /// Информация о версии ПО.
  /// </summary>
  [DataContract]
  public class VersionInfo
  {
    #region Свойства

    /// <summary>
    /// Программа.
    /// </summary>
    [DataMember]
    public string Program
    { get; set; }

    /// <summary>
    /// Установленная версия.
    /// </summary>
    [DataMember]
    public string VersionNumber
    { get; set; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// xml ctor.
    /// </summary>
    public VersionInfo()
    { }

    /// <summary>
    /// ctor.
    /// </summary>
    /// <param name="program">программа</param>
    /// <param name="version">версия</param>
    public VersionInfo(string program, string version)
    {
      Program = program;
      VersionNumber = version;
    }

    #endregion
  }
}
