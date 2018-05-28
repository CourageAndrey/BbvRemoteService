using System;
using System.Globalization;
using System.Net;
using System.ServiceModel;

namespace AuxService.Core.Transfer
{
	/// <summary>
	/// Статический класс, описывающий правила взаимодействия клиентской и серверной частей.
	/// </summary>
	public static class Protocol
	{
		/// <summary>
		/// Порт для обмена данными клиент-сервер.
		/// </summary>
		public const int ConnectionPort = 1987;

		/// <summary>
		/// Наименование службы.
		/// </summary>
		public const string ServiceName = "BbvAuxService";

		/// <summary>
		/// Формат адреса службы.
		/// </summary>
		public const string ServiceAddressFormat = @"http://{0}:{1}/{2}";

		/// <summary>
		/// TCP-запрос.
		/// </summary>
		/// <param name="ip">IP-адрес клиента</param>
		/// <returns>прокси клиентского сервиса</returns>
		public static ISalePointService CreateClientProxy(string ip)
		{
			var endPoint = new EndpointAddress(new Uri(string.Format(CultureInfo.InvariantCulture, ServiceAddressFormat, ip, ConnectionPort, ServiceName)));
			return new ChannelFactory<ISalePointService>(new BasicHttpBinding(), endPoint).CreateChannel();
		}

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
