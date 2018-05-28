using System.Collections.Generic;
using System.ServiceModel;

using AuxService.Core.SalePoints.Queries;

namespace AuxService.Core.Transfer
{
	/// <summary>
	/// WCF-Сервис клиента.
	/// </summary>
	[ServiceContract]
	public interface ISalePointService
	{
		/// <summary>
		/// Чтение журнала работы.
		/// </summary>
		/// <returns>список записей журнала работы</returns>
		[OperationContract]
		List<LogInfo> GetLog();

		/// <summary>
		/// Чтение журнала принтера.
		/// </summary>
		/// <returns>список записей журнала принтера</returns>
		[OperationContract]
		List<PrintInfo> GetSpooler();

		/// <summary>
		/// Чтение состояний служб.
		/// </summary>
		/// <returns>список записей состояний служб</returns>
		[OperationContract]
		List<StatusInfo> GetServicesStatus();

		/// <summary>
		/// Чтение системных параметров.
		/// </summary>
		/// <returns>словарь системной информации</returns>
		[OperationContract]
		SystemInfo GetSystemInfo();

		/// <summary>
		/// Чтение параметров 3G-сети.
		/// </summary>
		/// <returns>настройки 3G-сети</returns>
		[OperationContract]
		List<VelcomInfo> GetVelcomParameters();

		/// <summary>
		/// Чтение версий установленного ПО
		/// </summary>
		/// <returns>список версий установленного ПО</returns>
		[OperationContract]
		List<VersionInfo> GetVersions();
	}
}
