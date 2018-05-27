using System;
using System.Collections.Generic;
using System.Text;
using Sef.Utility.Log;
using Sef.Utility.Xml;

namespace AuxService.Core.SalePoints
{
  /// <summary>
  /// Разборщик лога AISURT-а.
  /// </summary>
  public static class ModisLogParser
  {
    /// <summary>
    /// Преобразование журнала из старого формата в новый.
    /// </summary>
    /// <param name="log">строка ссобщений</param>
    /// <returns>итоговая строка</returns>
    public static string Convert(IEnumerable<string> log)
    {
      var result = new StringBuilder();
      foreach (var line in log)
      {
        var fields = line.Split(FieldSeparator);
        
        // поля
        string date = fields[1].Trim();
        string thread = fields[2].Trim().TrimStart('[').TrimEnd(']');
        string type = fields[3].Trim().ToLower();
        string message = fields[7].Trim();
        string exception = fields[8].Trim();
        
        // thread id
        try
        {
          int tid = System.Convert.ToInt32(thread);
          thread = String.Format("0x{0:X8}", tid);
        }
        catch (FormatException)
        { }

        // exception
        if (exception.StartsWith(": "))
          message += exception;

        var record = new EventRecord(
          getDate(date),
          thread,
          getType(type),
          message.Substring(2),
          null);
        result.AppendLine(XmlHelper.SerializeElement(record).OuterXml + '·');
      }

      return result.ToString();
    }

    private static DateTime getDate(string value)
    {
      int year = System.Convert.ToInt32(value.Substring(6, 4));
      int month = System.Convert.ToInt32(value.Substring(3, 2));
      int day = System.Convert.ToInt32(value.Substring(0, 2));
      int hour = System.Convert.ToInt32(value.Substring(11, 2));
      int minute = System.Convert.ToInt32(value.Substring(14, 2));
      int second = System.Convert.ToInt32(value.Substring(17, 2));
      int millisecond = System.Convert.ToInt32(value.Substring(20, 1));
      return new DateTime(year, month, day, hour, minute, second, millisecond*100);
    }

    private static MessageType getType(string value)
    {
      value = value.ToLower();
      return definedTypes.ContainsKey(value)
        ? definedTypes[value]
        : MessageType.Information;
    }

    /// <summary>
    /// Разделитель строк.
    /// </summary>
    public const char LineSeparator = '¶';

    /// <summary>
    /// Разделитель полей.
    /// </summary>
    public const char FieldSeparator = '·';

    private static readonly Dictionary<string, MessageType> definedTypes = new Dictionary<string, MessageType>
    {
      { "error", MessageType.Error },
      { "fatal", MessageType.Fatal },
      { "warning", MessageType.Warning },
    };
  }
}
