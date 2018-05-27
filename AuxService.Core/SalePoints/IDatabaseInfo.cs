using System.Data.Common;

namespace AuxService.Core.SalePoints
{
  /// <summary>
  /// Информация из БД.
  /// </summary>
  public interface IDatabaseInfo
  {
    /// <summary>
    /// Чтение свойств из БД.
    /// </summary>
    /// <param name="reader">DbDataReader</param>
    void LoadProperties(DbDataReader reader);
  }
}
