using System.Runtime.Serialization;

namespace AuxService.Core.SalePoints.Queries
{
  /// <summary>
  /// Журнал работы приложения.
  /// </summary>
  [DataContract]
  public class LogInfo
  {
    #region Свойства

    /// <summary>
    /// Программа.
    /// </summary>
    [DataMember]
    public string Program
    { get; set; }

    /// <summary>
    /// Журнал.
    /// </summary>
    [DataMember]
    public string Log
    { get; set; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// xml ctor.
    /// </summary>
    public LogInfo()
    { }

    /// <summary>
    /// ctor.
    /// </summary>
    /// <param name="program">программа</param>
    /// <param name="log">журнал</param>
    public LogInfo(string program, string log)
    {
      Program = program;
      Log = log;
    }

    #endregion
  }
}
