using System.Collections.Generic;
using System.Data.Common;
using System.Xml.Serialization;

namespace AuxService.Core.SalePoints
{
  /// <summary>
  /// Запись о точке в XML.
  /// </summary>
  public class SalePointRecordXml
  {
    /// <summary>
    /// Код.
    /// </summary>
    [XmlAttribute]
    public string Code
    { get; set; }

    /// <summary>
    /// IP-адрес.
    /// </summary>
    [XmlAttribute]
    public string IP
    { get; set; }

    /// <summary>
    /// Установлена ли служба.
    /// </summary>
    [XmlAttribute]
    public bool AUX
    { get; set; }
  }

  /// <summary>
  /// Полная информация о запрошенных журналах работы.
  /// </summary>
  public class SalePointList
  {
    /// <summary>
    /// Программа.
    /// </summary>
    [XmlArray("All")]
    [XmlArrayItem("SalePoint")]
    public List<SalePointRecordXml> SalePoints
    { get; set; }
  }

  /// <summary>
  /// Запись о точке в SQL.
  /// </summary>
  public class SalePointRecordSql : IDatabaseInfo
  {
    #region Свойства

    /// <summary>
    /// Идентификатор БД.
    /// </summary>
    public long ID
    { get; private set; }

    /// <summary>
    /// Код ПР.
    /// </summary>
    public string Code
    { get; private set; }

    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name
    { get; private set; }

    /// <summary>
    /// Адрес.
    /// </summary>
    public string Address
    { get; private set; }

    /// <summary>
    /// Область.
    /// </summary>
    public long Region
    { get; private set; }

    #endregion

    /// <summary>
    /// Чтение свойств из БД.
    /// </summary>
    /// <param name="reader">DbDataReader</param>
    public void LoadProperties(DbDataReader reader)
    {
      ID = (long)reader["ID"];
      Code = (string)reader["Code"];
      Name = (string)reader["Name"];
      if (Name.IndexOf(',') > 0)
        Name = Name.Remove(Name.IndexOf(','));
      Address = (string)reader["Address"];
      Region = (int)reader["Region"];
    }

  }
}
