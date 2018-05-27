using System;
using System.Collections.Generic;
using AuxService.Core.Helpers;
using AuxService.Core.SalePoints.Queries;
using AuxService.Core.Service;
using AuxService.Core.Transfer;
using Sef.Utility.Log;
using Sef.Utility.Xml;

namespace AuxService.ClientService
{
  internal partial class ClientService
  {
    // когда получен запрос от сервера
    private void server_Receive(object sender, ServerEventArgs e)
    {
      //подготовка к приёму
      OsHelper.RenameCurrentThread(Constants.ThreadTcp);

      // сохранение запроса в журнале
      LogHelper.Write(logMain, MessageType.Information, string.Format(
        "Получено сообщение от сервера {0}: \"{1}\"",
        e.Packet.SenderName,
        e.Packet.Message));

      // определение типа запроса и формирование ответа
      string request = e.Packet.Message.Substring(0, 5);
      string code = e.Packet.SenderCode;
      if (!answerHandlers.ContainsKey(request))
        throw new NotSupportedException(string.Format("Тип сообщения \"{0}\" не поддерживается!", request));
      var response = XmlHelper.SerializeElement(answerHandlers[request].Invoke());
      response.SetAttribute("SenderCode", code);

      // отправка ответа серверу
      Client.Send(e.Packet.SenderIp.ToString(), Protocol.ConnectionPort, request + response.OuterXml, code);

      // Запись в журнал
      LogHelper.Write(logMain, MessageType.Information, string.Format("Сформирован и отправлен ответ серверу {0}", e.Packet.SenderName));
    }

    // корректные ответы на запрос
    private static readonly Dictionary<string, Func<object>> answerHandlers = new Dictionary<string, Func<object>>
    {
      { Protocol.GetHardSign, () => SystemInfo.Request() },
      { Protocol.GetLogsSign, () => LogInfoList.Request() },
      { Protocol.GetStatusSign, () => StatusInfoList.Request() },
      { Protocol.GetVersionsSign, () => VersionInfoList.Request() },
      { Protocol.GetTrafficSign, () => VelcomInfoList.Request() },
      { Protocol.GetPrintedSign, () => PrintInfoList.Request() }
    };
  }
}
