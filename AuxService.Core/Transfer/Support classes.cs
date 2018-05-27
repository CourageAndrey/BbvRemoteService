using System;
using System.Net.Sockets;

namespace AuxService.Core.Transfer
{
  /// <summary>
  /// Аргумент события сервера "получено сообщение".
  /// </summary>
  public class ServerEventArgs : EventArgs
  {
    /// <summary>
    /// Полученный пакет.
    /// </summary>
    public readonly Packet Packet;

    /// <summary>
    /// ctor.
    /// </summary>
    /// <param name="packet">пакет</param>
    public ServerEventArgs(Packet packet)
    {
      Packet = packet;
    }
  }

  /// <summary>
  /// Состояние, используемое сервером для корректной обработки пакета.
  /// </summary>
  public class MessageState
  {
    /// <summary>
    /// Отправитель.
    /// </summary>
    public readonly object Sender;

    /// <summary>
    /// Клиент, который переслал данные.
    /// </summary>
    public readonly TcpClient Client;

    /// <summary>
    /// Буфер с прочитанными данными.
    /// </summary>
    public readonly byte[] Buffer;

    /// <summary>
    /// Обработчик принятия сообщения.
    /// </summary>
    public readonly EventHandler<ServerEventArgs> Receive;

    /// <summary>
    /// ctor.
    /// </summary>
    /// <param name="sender">отправитель</param>
    /// <param name="client">клиент</param>
    /// <param name="buffer">данные</param>
    /// <param name="receive">обработчик</param>
    public MessageState(object sender, TcpClient client, byte[] buffer, EventHandler<ServerEventArgs> receive)
    {
      Sender = sender;
      Client = client;
      Buffer = buffer;
      Receive = receive;
    }
  }
}
