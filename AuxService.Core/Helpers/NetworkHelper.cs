using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Xml;
using AuxService.Core.Transfer;
using ICSharpCode.SharpZipLib.Zip;

namespace AuxService.Core.Helpers
{
  /// <summary>
  /// Класс для работы с сетью.
  /// </summary>
  public static class NetworkHelper
  {
    /// <summary>
    /// Отправка сообщения.
    /// </summary>
    /// <param name="hostname">адресат</param>
    /// <param name="port">порт</param>
    /// <param name="packet">сообщение</param>
    public static void Send(string hostname, int port, XmlElement packet)
    {
      try
      {
        using (var client = new TcpClient(hostname, port)) // создали новое подключение
        {
          var stream = client.GetStream(); // получили поток для записи
          var message = createMessage(packet); // подготовили пакет к отправке
          var lenght = BitConverter.GetBytes(message.Length); // получили длину
          stream.Write(lenght, 0, lenght.Length); // записали размер данных
          int pos = 0; int total = message.Length;
          while (pos < total)
          {
            int size = Math.Min(Protocol.BufferSize, total - pos);
            stream.Write(message, pos, size); // в цикле пишем данные пакетами размером Protocol.BufferSize (4 Кб)
            pos += size;
          }
          stream.Flush(); // гарантированно отсылаем данные
          client.Close(); // закрываем соединение
        }
      }
      catch
      { }
    }

    /// <summary>
    /// Обработчик чтения данных сервером.
    /// </summary>
    /// <param name="ar">входящее сообщение</param>
    public static void OnRead(IAsyncResult ar)
    {
      if (!ar.IsCompleted) // если данные не передались
        return;            // уходим из этой песочницы
      try
      {
        var state = (MessageState) ar.AsyncState; // получаем принятое сообщение
        int length = BitConverter.ToInt32(state.Buffer, 0); // здесь
        var buffer = new byte[length];                      // читаем
        var stream = state.Client.GetStream();              // длину
        stream.EndRead(ar);                                 // принятого пакета

        int pos = 0;                                                                    // здесь читаем
        while (pos < length)                                                            // в цикле все
          pos += stream.Read(buffer, pos, Math.Min(length - pos, Protocol.BufferSize)); // данные кусками
        state.Client.Close();                                                           // по Protocol.BufferSize (4 Кб)
        
        var packet = Packet.Unpack(parseMessage(buffer)); // грузим из данных пакет
        
        var handler = state.Receive;
        if (handler != null)
          handler(state.Sender, new ServerEventArgs(packet)); // запускаем обработчик принятого пакета
      }
      catch
      { }
    }

    // упаковка пакета к отправке
    private static byte[] createMessage(XmlElement packet)
    {
      // преобразуеми в строку и добавляем маркер конца
      string fullMessage = packet.OuterXml + Protocol.EndSign;

      var tempFile = Path.GetTempFileName(); // создаём временный файл
      File.WriteAllText(tempFile, fullMessage); // скидываем в него сообщение
      var tempZip = Path.GetTempFileName(); // создаём второй временный файл
      tempZip = Path.ChangeExtension(tempZip, ".zip"); // который переименовываем в zip
      using (var archive = ZipFile.Create(tempZip)) // создаём zip-архив из второго файла
      {
        archive.BeginUpdate();
        archive.Add(tempFile, zipEntryName); // запаковываем первый файл в архив
        archive.CommitUpdate();
      }

      var dataZip = File.ReadAllBytes(tempZip); // вычитываем новый архив
      var dataRaw = Encoding.UTF8.GetBytes(fullMessage); // получаем байты строки сообщения
      
      File.Delete(tempFile); // удаляем временный файл
      File.Delete(tempZip); // удаляем архив

      return (dataRaw.Length > dataZip.Length) ? dataZip : dataRaw; // отправляем наименьший из пакетов
    }

    // разбор пришедшего сообщения
    private static XmlElement parseMessage(byte[] data)
    {
      if (Protocol.IsArchive(data)) // если пришёл архив
      {
        var tempZip = Path.GetTempFileName(); // создаём временный файл
        tempZip = Path.ChangeExtension(tempZip, ".zip"); // превращаем его в архив
        File.WriteAllBytes(tempZip, data); // пишем в него все пришедшие данные
        var tempFolder = Path.GetTempFileName(); // получаем второй временный файл
        tempFolder = tempFolder.Remove(tempFolder.LastIndexOf(".")); // превращаем его в папку
        new FastZip().ExtractZip(tempZip, tempFolder, null); // распаковываем в неё архив
        var folder = new DirectoryInfo(tempFolder); // подключаемся к ней
        var file = folder.GetFiles()[0]; // берём первый файл
        data = File.ReadAllBytes(file.FullName); // и читаем из него пакет
        File.Delete(tempZip); // удаляем временный архив
        Sef.Utility.Common.FileSystemHelper.Delete(folder); // удаляем временную папку целиком
      }
        
      string message = Encoding.UTF8.GetString(data).Trim(new[] { '\0' }); // преобразуем сообщение в строку
      if (!message.EndsWith(Protocol.EndSign)) // если пакет пришёл не целиком или не завершён
        throw new Exception("Пакет не завершён!");                   // ругаемся
      message = message.Remove(message.Length - Protocol.EndSign.Length); // отрезаем от пакета терминатор
      var document = new XmlDocument { InnerXml = message };  // грузим строку в XML
      
      return document.DocumentElement;
    }

    private const string zipEntryName = "MainData";

    /// <summary>
    /// Получение IP-адреса компьютера.
    /// </summary>
    /// <returns>IPAddress</returns>
    public static IPAddress GetLocalIP()
    {
      return Dns.GetHostEntry(Dns.GetHostName()).AddressList[0];
    }
  }
}
