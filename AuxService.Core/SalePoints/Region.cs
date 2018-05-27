using System.Data.Common;

namespace AuxService.Core.SalePoints
{
  /// <summary>
  /// Область.
  /// </summary>
  public class Region : IDatabaseInfo
  {
    #region Свойства

    /// <summary>
    /// Идентификатор.
    /// </summary>
    public long ID
    { get; private set; }

    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name
    { get; private set; }

    #endregion

    /// <summary>
    /// Чтение свойств из БД.
    /// </summary>
    /// <param name="reader">DbDataReader</param>
    public void LoadProperties(DbDataReader reader)
    {
      ID = (long) reader["ID"];
      Name = (string) reader["Name"];
    }
  }
}
