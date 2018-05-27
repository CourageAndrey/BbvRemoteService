using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using Sef.Utility.Common;

namespace AuxService.Core.SalePoints.Queries
{
  /// <summary>
  /// Журнал работы приложения.
  /// </summary>
  public class LogInfo
  {
    #region Свойства

    /// <summary>
    /// Программа.
    /// </summary>
    [XmlAttribute]
    public string Program
    { get; set; }

    /// <summary>
    /// Журнал.
    /// </summary>
    [XmlAttribute]
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

  /// <summary>
  /// Полная информация о запрошенных журналах работы.
  /// </summary>
  public class LogInfoList
  {
    #region Свойства

    /// <summary>
    /// Программа.
    /// </summary>
    [XmlArray("Logs")]
    [XmlArrayItem("Log")]
    public List<LogInfo> Logs
    { get; set; }

    #endregion

    /// <summary>
    /// Запрос информации.
    /// </summary>
    /// <returns>список журналов</returns>
    public static LogInfoList Request()
    {
      var result = new LogInfoList();
      result.Logs = new List<LogInfo>
      {
        new LogInfo("AisurtClient", readFromFile(@"C:\Program Files\ModIS-M\BlankPublish\Log\Client.log")),
        new LogInfo("AisurtAgent", readFromFile(@"C:\Program Files\ModIS-M\BlankPublish\Log\Agent.log")),
        new LogInfo("AuxService", readFromFile(Path.Combine(Application.StartupPath, "Log\\Service.log")))
      };
      return result;
    }

    // безопасное чтение из файла
    private static string readFromFile(string fileName)
    {
      try
      {
        return File.ReadAllText(fileName, FileSystemHelper.GetFileEncoding(fileName));
      }
      catch (Exception ex)
      {
        return string.Format("{0} {1}", ex.GetType().Name, ex.Message);
      }
    }
  }
}
