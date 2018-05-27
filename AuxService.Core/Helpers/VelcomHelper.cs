using System;
using System.Xml;
using System.Xml.Serialization;
using Sef.Utility.Xml;

namespace AuxService.Core.Helpers
{
  /// <summary>
  /// Информация по трафику.
  /// </summary>
  public class VelcomHelper
  {
    #region Свойства

    /// <summary>
    /// Байт за этот день получено.
    /// </summary>
    [XmlAttribute]
    public long DayDownloaded
    { get; set; }

    /// <summary>
    /// Байт за этот день отправлено.
    /// </summary>
    [XmlAttribute]
    public long DayUploaded
    { get; set; }

    /// <summary>
    /// Байт за эту неделю получено.
    /// </summary>
    [XmlAttribute]
    public long WeekDownloaded
    { get; set; }

    /// <summary>
    /// Байт за эту неделю отправлено.
    /// </summary>
    [XmlAttribute]
    public long WeekUploaded
    { get; set; }

    /// <summary>
    /// Байт за этот месяц получено.
    /// </summary>
    [XmlAttribute]
    public long MonthDownloaded
    { get; set; }

    /// <summary>
    /// Байт за этот месяц отправлено.
    /// </summary>
    [XmlAttribute]
    public long MonthUploaded
    { get; set; }

    /// <summary>
    /// Байт за этот год получено.
    /// </summary>
    [XmlAttribute]
    public long YearDownloaded
    { get; set; }

    /// <summary>
    /// Байт за этот год отправлено.
    /// </summary>
    [XmlAttribute]
    public long YearUploaded
    { get; set; }

    #endregion

    /// <summary>
    /// Запрос информации.
    /// </summary>
    public static VelcomHelper Request()
    {
      var doc = new XmlDocument();
      doc.Load(@"c:\Program Files\3G Internet\userdata\NetInfo.dat");
      var root = doc.DocumentElement;
      XmlElement info = null;
      foreach (var child in XmlHelper.SelectChilds(root, "transfer"))
        if (child.HasAttribute("type") && child.GetAttribute("type")=="Dial-up")
        {
          info = child;
          break;
        }

      if (info == null)
        throw new Exception("Не могу прочитать информацию!");

      var velcom = new VelcomHelper();

      var day = XmlHelper.SelectChild(info, "today");
      var week = XmlHelper.SelectChild(info, "this_week");
      var month = XmlHelper.SelectChild(info, "this_month");
      var year = XmlHelper.SelectChild(info, "this_year");

      velcom.DayDownloaded = Convert.ToInt64(day.GetAttribute("downloaded"));
      velcom.DayUploaded = Convert.ToInt64(day.GetAttribute("uploaded"));
      velcom.WeekDownloaded = Convert.ToInt64(week.GetAttribute("downloaded"));
      velcom.WeekUploaded = Convert.ToInt64(week.GetAttribute("uploaded"));
      velcom.MonthDownloaded = Convert.ToInt64(month.GetAttribute("downloaded"));
      velcom.MonthUploaded = Convert.ToInt64(month.GetAttribute("uploaded"));
      velcom.YearDownloaded = Convert.ToInt64(year.GetAttribute("downloaded"));
      velcom.YearUploaded = Convert.ToInt64(year.GetAttribute("uploaded"));

      return velcom;
    }
  }
}
