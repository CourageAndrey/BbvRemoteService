using System;
using System.Net;
using System.Net.Sockets;
using AuxService.Core.Helpers;

namespace AuxService.Core.Transfer
{
  /// <summary>
  /// Сервер приёма данных.
  /// </summary>
  public class Server
  {
    /// <summary>
    /// Событие: принят пакет.
    /// </summary>
    public event EventHandler<ServerEventArgs> Receive;

    // Listener, слушающий порт
    private readonly TcpListener listener;

    /// <summary>
    /// ctor.
    /// </summary>
    public Server()
    {
      listener = new TcpListener(IPAddress.Any, Protocol.ConnectionPort);
      listener.Start();
      listener.BeginAcceptTcpClient(onConnect, listener);
    }

    // событие, возникющее при получении данных
    private void onConnect(IAsyncResult asyncResult)
    {
      // корректно подключаемся к клиенту
      var client = listener.EndAcceptTcpClient(asyncResult);
      // создаем буфер, в который будет передана длина пакета
      var buffer = new byte[sizeof(int)];
      // ждём длину пакета
      client.GetStream().BeginRead(buffer, 0, sizeof(int), NetworkHelper.OnRead, new MessageState(this, client, buffer, Receive));
      // продолжаем слушать порт
      listener.BeginAcceptTcpClient(onConnect, listener);
    }
  }
}
