using System;
using AuxService.Core.Helpers;
using Sef.Utility.Applications;

namespace AuxService.Core.Transfer
{
  /// <summary>
  /// Клиент пересылки данных.
  /// </summary>
  public static class Client
  {
    /// <summary>
    /// Отправка сообщения.
    /// </summary>
    /// <param name="address">адрес -кому</param>
    /// <param name="port">номер порта</param>
    /// <param name="packet">сообщение</param>
    /// <param name="code">код отправителя</param>
    /// <returns>возникшая в процессе отправки ошибка, или <b>null</b> если всё ОК</returns>
    public static ExceptionWrapper Send(string address, int port, string packet, string code)
    {
      try
      {
        NetworkHelper.Send(address, port, new Packet(packet, code).Pack());
        return null;
      }
      catch (Exception ex)
      {
        return new ExceptionWrapper(ex);
      }
    }
  }
}
