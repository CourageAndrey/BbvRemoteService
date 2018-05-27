using System;
using System.Collections.Generic;
using System.Data.Common;

namespace AuxService.Core.SalePoints
{
  /// <summary>
  /// Контактные данные ПР.
  /// </summary>
  public class Contact : IDatabaseInfo
  {
    #region Свойства

    /// <summary>
    /// Пункт реализации.
    /// </summary>
    public long SalePoint
    { get; private set; }

    /// <summary>
    /// Список телефонов.
    /// </summary>
    public List<string> Telephones
    { get; private set; }

    /// <summary>
    /// Список мобильных.
    /// </summary>
    public List<string> Mobiles
    { get; private set; }

    /// <summary>
    /// Список факсов.
    /// </summary>
    public List<string> Faxes
    { get; private set; }

    #endregion
    
    /// <summary>
    /// Чтение свойств из БД.
    /// </summary>
    /// <param name="reader">DbDataReader</param>
    public void LoadProperties(DbDataReader reader)
    {
      SalePoint = (long) reader["SubjectID"];
      Telephones = new List<string>(split(reader["Phone"]));
      Mobiles = new List<string>(split(reader["MobilePhone"]));
      Faxes = new List<string>(split(reader["FAX"]));
    }

    // разделение строки на отдельные номера
    private static IEnumerable<string> split(object number)
    {
      var list = new List<string>();

      if (number != DBNull.Value)
        foreach (var num in ((string) number).Split(','))
          list.Add(num.Trim());

      return list;
    }
  }
}
