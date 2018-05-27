using System;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using AuxService.Core.Helpers;
using Sef.Utility.Xml;

namespace AuxService.Core.Transfer
{
  /// <summary>
  /// Пакет отправки дпнных.
  /// </summary>
  public class Packet
  {
    #region Свойства

    /// <summary>
    /// Отправитель - код.
    /// </summary>
    [XmlAttribute]
    public string SenderCode
    { get; set; }

    /// <summary>
    /// Отправитель - HostName.
    /// </summary>
    [XmlAttribute]
    public string SenderName
    { get; set; }

    /// <summary>
    /// Отправитель - IP.
    /// </summary>
    [XmlIgnore]
    public IPAddress SenderIp
    { get; set; }

    /// <summary>
    /// Отправитель - IP.
    /// </summary>
    [XmlAttribute]
    public string SenderIpXml
    { get; set; }

    /// <summary>
    /// Текстовое сообщение.
    /// </summary>
    [XmlAttribute]
    public string Message
    { get; set; }

    /// <summary>
    /// Время отправки.
    /// </summary>
    [XmlAttribute]
    public DateTime TimeStamp
    { get; set; }

    #endregion

    #region Конструкторы

    /// <summary>
    /// empty ctor.
    /// </summary>
    public Packet()
    { }

    /// <summary>
    /// ctor.
    /// </summary>
    /// <param name="message">сообщение</param>
    /// <param name="code">код отправителя</param>
    public Packet(string message, string code)
    {
      SenderCode = code;
      SenderIp = NetworkHelper.GetLocalIP();
      SenderName = Dns.GetHostName();
      Message = message;
      TimeStamp = DateTime.Now;
    }

    #endregion

    #region Передача

    /// <summary>
    /// Упаковка.
    /// </summary>
    /// <returns>xml</returns>
    public XmlElement Pack()
    {
      SenderIpXml = SenderIp.ToString();
      var element = XmlHelper.SerializeElement(this);
      return element;
    }

    /// <summary>
    /// Упаковка.
    /// </summary>
    /// <param name="xml">xml</param>
    /// <returns>пакет</returns>
    public static Packet Unpack(XmlElement xml)
    {
      var packet = XmlHelper.DeserializeXml<Packet>(xml.OuterXml);
      packet.SenderIp = IPAddress.Parse(packet.SenderIpXml);
      return packet;
    }

    #endregion
  }
}
