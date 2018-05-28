using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

using AuxService.Core.Helpers;
using AuxService.Core.SalePoints.Queries;
using AuxService.Core.Service;
using AuxService.Core.Settings;
using AuxService.Core.Transfer;

using Sef.Utility.Common;
using Sef.Utility.Database;
using Sef.Utility.Xml;

namespace AuxService.ClientService
{
	internal class SalePointService : ISalePointService
	{
		public List<LogInfo> GetLog()
		{
			return new List<LogInfo>
			{
				new LogInfo("AisurtClient", readFromFile(@"C:\Program Files\ModIS-M\BlankPublish\Log\Client.log")),
				new LogInfo("AisurtAgent", readFromFile(@"C:\Program Files\ModIS-M\BlankPublish\Log\Agent.log")),
				new LogInfo("AuxService", readFromFile(Path.Combine(Application.StartupPath, @"Log\Service.log")))
			};
		}

		public List<PrintInfo> GetSpooler()
		{
			var result = new List<PrintInfo>();
			var spooler = new DirectoryInfo(Path.Combine(Application.StartupPath, "Spooler"));
			foreach (var file in spooler.GetFileSystemInfos("*.log*"))
			{
				var text = File.ReadAllText(file.FullName, FileSystemHelper.GetFileEncoding(file.FullName));
				var lines = text.Split(spoolerSeparator);
				foreach (var line in lines)
				{
					if (!string.IsNullOrEmpty(line.Trim()))
					{
						result.Add(XmlHelper.DeserializeXml<PrintInfo>(line));
					}
				}
			}
			return result;
		}

		public List<StatusInfo> GetServicesStatus()
		{
			var result = new List<StatusInfo>();
			foreach (var serviceName in Config.Instance.ControlledServices)
			{
				var service = new ServiceRecord(serviceName);
				result.Add(new StatusInfo(service.ServiceName, service.StatusString, service.IsInstalled && !service.IsStopped));
			}
			return result;
		}

		public SystemInfo GetSystemInfo()
		{
			var info = new SystemInfo();
			try
			{
				var cpu = WmiHelper.First(WmiHelper.QueryInfo("Win32_Processor"));
				info.Processor = new CPU
				{
					Name = (string)cpu["Name"],
					SpeedMHz = (uint)cpu["CurrentClockSpeed"]
				};

				var memory = WmiHelper.First(WmiHelper.QueryInfo("Win32_LogicalMemoryConfiguration"));
				info.Memory = (uint)memory["TotalPhysicalMemory"] * 1024;

				var motherboard = WmiHelper.First(WmiHelper.QueryInfo("Win32_BaseBoard"));
				info.MotherBoard = new MotherBoard
				{
					Manufacturer = (string)motherboard["Manufacturer"],
					Model = (string)motherboard["Product"]
				};

				foreach (var disk in Environment.GetLogicalDrives())
				{
					var drive = new DriveInfo(disk);
					if (drive.IsReady)
					{
						info.HDD.Add(new Disk
						{
							Name = drive.Name,
							Label = drive.VolumeLabel,
							TotalSpace = drive.TotalSize,
							FreeSpace = drive.AvailableFreeSpace
						});
					}
				}

				info.Printers.AddRange(PrintInfo.GetPrinterList());
				foreach (var printer in WmiHelper.QueryInfo("Win32_Printer"))
				{
					string name = (string)printer.Properties["Caption"].Value;
					var printerInfo = info.Printers.Find(p => p.Caption == name);
					if (printerInfo != null)
					{
						printerInfo.Model = (string)printer.Properties["DriverName"].Value;
					}
				}

				info.HostName = SystemInformation.ComputerName;

				foreach (var address in Dns.GetHostEntry(info.HostName).AddressList)
				{
					info.IPAddresses.Add(address.ToString());
				}

				info.UserName = SystemInformation.UserName; // можно также через System.Enironment.UserName
			}
			catch
			{ }
			return info;
		}

		public List<VelcomInfo> GetVelcomParameters()
		{
			var velcom = VelcomHelper.Request();
			return new List<VelcomInfo>
			{
				new VelcomInfo("Получено за день", velcom.DayDownloaded),
				new VelcomInfo("Отправлено за день", velcom.DayUploaded),
				new VelcomInfo("Получено за неделю", velcom.WeekDownloaded),
				new VelcomInfo("Отправлено за неделю", velcom.WeekUploaded),
				new VelcomInfo("Получено за месяц", velcom.MonthDownloaded),
				new VelcomInfo("Отправлено за месяц", velcom.MonthUploaded),
				new VelcomInfo("Получено за год", velcom.YearDownloaded),
				new VelcomInfo("Отправлено за год", velcom.YearUploaded)
			};
		}

		public List<VersionInfo> GetVersions()
		{
			// запрос версий
			var windows = WmiHelper.First(WmiHelper.QueryInfo("Win32_OperatingSystem"));
			var bdb = getDbVersion("BaseComplex", "select max(Version) from Db_verson");
			var bdb2 = getDbVersion("BaseComplex2", "select max(Version) from Db_version");
			var aisurt = getAisurtVersion();
			// запись результата
			return new List<VersionInfo>
			{
				new VersionInfo("ОС Windows", string.Format("{0} {1}", windows["Caption"], windows["CSDVersion"])),
				new VersionInfo("SQL Server", DatabaseHelper.Instance.GetServerVersion(ConnectionWrapper.CreateLoginPassword(string.Empty, "master", "sa", string.Empty).ConnectionString)),
				new VersionInfo("АС БДБ", prepare(bdb)),
				new VersionInfo("АМ КЗ", prepare(bdb2)),
				new VersionInfo("АИС УРТ", aisurt),
				new VersionInfo("Aux Service", Assembly.GetExecutingAssembly().GetName().Version.ToString())
			};
		}

		#region Helpers

		// безопасное чтение из файла
		private static string readFromFile(string fileName)
		{
			try
			{
				return File.ReadAllText(fileName, FileSystemHelper.GetFileEncoding(fileName));
			}
			catch (Exception ex)
			{
				return string.Format("{0} {1}", ex.GetType().Name, ex.Message);
			}
		}

		// разделитель строк
		private const char spoolerSeparator = '·';

		private static string getDbVersion(string db, string query)
		{
			string version;
			SqlConnection connection = null;
			try
			{
				connection = new SqlConnection(ConnectionWrapper.CreateLoginPassword(string.Empty, db, "sa", string.Empty).ConnectionString);
				connection.Open();
				version = ((int)new SqlCommand(query, connection).ExecuteScalar()).ToString();
			}
			catch (Exception)
			{
				version = string.Format("~БД \"{0}\" не установлена или не доступна.", db);
			}
			finally
			{
				if (connection != null && connection.State == ConnectionState.Open)
					connection.Close();
			}
			return version;
		}

		// получение версии АИСУРТ
		// берётся не из БД, а из файла BlankPublish.ClientShell.exe
		private static string getAisurtVersion()
		{
			try
			{
				var version = FileVersionInfo.GetVersionInfo(@"c:\Program Files\ModIS-M\BlankPublish\BlankPublish.ClientShell.exe");
				return version.ProductVersion;
			}
			catch (Exception)
			{
				return "\"АИСУРТ\" не установлен или не доступен!";
			}
		}

		// подготовка версий АС БДБ и АМ КБ
		private static string prepare(string version)
		{
			if (version.StartsWith("~"))
			{
				return version.Substring(1);
			}
			if (version.IndexOf(".") < 1)
			{
				return string.Format("{0}.{1}.{2}", version.Substring(0, 1), version.Substring(1, 2), version.Substring(3, 4));
			}
			return version;
		}

		#endregion
	}
}
