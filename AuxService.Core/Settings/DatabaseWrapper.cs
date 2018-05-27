using System.Xml.Serialization;
using Sef.Utility.Database;

namespace AuxService.Core.Settings
{
  /// <summary>
  /// Подключение к БД+.
  /// </summary>
  public class DatabaseWrapper
  {
    #region Свойства

    /// <summary>
    /// Подключение к БД.
    /// </summary>
    [XmlElement]
    public ConnectionWrapper Database
    { get; set; }

    /// <summary>
    /// Выполнять оптимизацию.
    /// </summary>
    [XmlAttribute]
    public bool Optimize
    { get; set; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// empty ctor.
    /// </summary>
    public DatabaseWrapper()
      : this(new ConnectionWrapper(), false)
    { }

    /// <summary>
    /// ctor.
    /// </summary>
    /// <param name="database">бд</param>
    /// <param name="optimize">оптимизания</param>
    public DatabaseWrapper(ConnectionWrapper database, bool optimize)
    {
      Database = database;
      Optimize = optimize;
    }

    #endregion
  }
}
