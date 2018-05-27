using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Serialization;
using AuxService.Core.Helpers;
using Sef.Utility.Database;

namespace AuxService.Core.SalePoints.Queries
{
  /// <summary>
  /// Информация о версии ПО.
  /// </summary>
  public class VersionInfo
  {
    #region Свойства

    /// <summary>
    /// Программа.
    /// </summary>
    [XmlAttribute]
    public string Program
    { get; set; }

    /// <summary>
    /// Установленная версия.
    /// </summary>
    [XmlAttribute]
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

  /// <summary>
  /// Полная информация о запрошенных версиях ПО.
  /// </summary>
  public class VersionInfoList
  {
    #region Свойства

    /// <summary>
    /// Программа.
    /// </summary>
    [XmlArray("Velcom")]
    [XmlArrayItem("Info")]
    public List<VersionInfo> Versions
    { get; set; }

    #endregion

    /// <summary>
    /// Запрос информации.
    /// </summary>
    /// <returns>список версий</returns>
    public static VersionInfoList Request()
    {
      // запрос версий
      var windows = WmiHelper.First(WmiHelper.QueryInfo("Win32_OperatingSystem"));
      var bdb = getDbVersion("BaseComplex", "select max(Version) from Db_verson");
      var bdb2 = getDbVersion("BaseComplex2", "select max(Version) from Db_version");
      var aisurt = getAisurtVersion();

      // запись результата
      var result = new VersionInfoList();
      result.Versions = new List<VersionInfo>
      {
        new VersionInfo("ОС Windows", string.Format("{0} {1}", windows["Caption"], windows["CSDVersion"])),
        new VersionInfo("SQL Server", DatabaseHelper.Instance.GetServerVersion(
          ConnectionWrapper.CreateLoginPassword(string.Empty, "master", "sa", string.Empty).ConnectionString)),
        new VersionInfo("АС БДБ", prepare(bdb)),
        new VersionInfo("АМ КЗ", prepare(bdb2)),
        new VersionInfo("АИС УРТ", aisurt),
        new VersionInfo("Aux Service", Assembly.GetExecutingAssembly().GetName().Version.ToString())
      };
      return result;
    }

    private static string getDbVersion(string db, string query)
    {
      string version;
      SqlConnection connection = null;
      try
      {
        connection = new SqlConnection(
          ConnectionWrapper.CreateLoginPassword(string.Empty, db, "sa", string.Empty).ConnectionString);
        connection.Open();
        version = ((int)new SqlCommand(query, connection).ExecuteScalar()).ToString();
      }
      catch (Exception)
      {
        version = string.Format("~БД \"{0}\" не установлена или не доступна.", db);
      }
      finally
      {
        if (connection != null && connection.State == ConnectionState.Open)
          connection.Close();
      }
      return version;
    }

    // получение версии АИСУРТ
    // берётся не из БД, а из файла BlankPublish.ClientShell.exe
    private static string getAisurtVersion()
    {
      try
      {
        var version = FileVersionInfo.GetVersionInfo(@"c:\Program Files\ModIS-M\BlankPublish\BlankPublish.ClientShell.exe");
        return version.ProductVersion;
      }
      catch (Exception)
      {
        return "\"АИСУРТ\" не установлен или не доступен!";
      }
    }

    // подготовка версий АС БДБ и АМ КБ
    private static string prepare(string version)
    {
      if (version.StartsWith("~"))
        return version.Substring(1);
      if (version.IndexOf(".") < 1)
        return string.Format("{0}.{1}.{2}", version.Substring(0, 1), version.Substring(1, 2), version.Substring(3, 4));
      return version;
    }
  }
}
