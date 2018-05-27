using System;
using System.Threading;

namespace AuxService.Core.Helpers
{
  /// <summary>
  /// Класс для взаимодействия с объектами ОС.
  /// </summary>
  public static class OsHelper
  {
    /// <summary>
    /// Переименование текущего потока.
    /// </summary>
    /// <param name="newName">новое имя</param>
    public static void RenameCurrentThread(string newName)
    {
      if (Thread.CurrentThread.Name != newName)
        Thread.CurrentThread.Name = newName;
    }

    /// <summary>
    /// Форматирование даты для имён файлов.
    /// </summary>
    /// <param name="stamp">дата</param>
    /// <returns>строковое представление</returns>
    public static string GetDateString(DateTime stamp)
    {
      return stamp.ToString("yyyy.MM.dd_HH.mm");
    }
  }
}
