using System;
using System.Data.Common;

namespace AuxService.Core.SalePoints
{
  /// <summary>
  /// Продавец.
  /// </summary>
  public class Person : IDatabaseInfo
  {
    #region Свойства

    /// <summary>
    /// Пункт реализации.
    /// </summary>
    public long SalePoint
    { get; private set; }

    /// <summary>
    /// ФИО.
    /// </summary>
    public string FIO
    { get; private set; }

    /// <summary>
    /// Должность.
    /// </summary>
    public string Position
    { get; private set; }

    #endregion

    /// <summary>
    /// Чтение свойств из БД.
    /// </summary>
    /// <param name="reader">DbDataReader</param>
    public void LoadProperties(DbDataReader reader)
    {
      SalePoint = (long) reader["SubjectID"];
      FIO = string.Format("{0} {1} {2}", reader["FName"], reader["IName"], reader["OName"]);
      Position = (reader["Position"] != DBNull.Value) ? (string) reader["Position"] : null;
    }
  }
}
