using System.Management;

namespace AuxService.Core.Helpers
{
  /// <summary>
  /// Класс для выполнения WMI-запросов.
  /// </summary>
  public static class WmiHelper
  {
    /// <summary>
    /// Запрос информации.
    /// </summary>
    /// <param name="table">имя запрашиваемой таблицы</param>
    /// <returns>ManagementObjectCollection</returns>
    public static ManagementObjectCollection QueryInfo(string table)
    {
      var scope = new ManagementScope(@"\\localhost\root\cimv2");
      scope.Connect();
      var query = new WqlObjectQuery("select * from " + table);
      var finder = new ManagementObjectSearcher(query);
      return finder.Get();
    }

    /// <summary>
    /// Выборка первого объекта из коллекции.
    /// </summary>
    /// <param name="collection">ManagementObjectCollection</param>
    /// <returns>ManagementBaseObject</returns>
    public static ManagementBaseObject First(ManagementObjectCollection collection)
    {
      ManagementBaseObject result = null;
      foreach (var info in collection)
      {
        result = info;
        break;
      }
      return result;
    }
  }
}
