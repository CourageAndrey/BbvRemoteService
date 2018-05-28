using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

using AuxService.Core.SalePoints;
using AuxService.Core.SalePoints.Forms;
using AuxService.Core.SalePoints.Queries;
using AuxService.Core.Transfer;

using DevExpress.XtraEditors;

using Sef.DX;
using Sef.Utility.Applications;
using Sef.Utility.Database;
using Sef.Utility.Xml;

namespace AuxService.ServerConsole
{
  /// <summary>
  /// Главная форма консоли сервера.
  /// </summary>
  public partial class ServerMainForm : XtraForm
  {
    #region Инициализация

    /// <summary>
    /// ctor.
    /// </summary>
    public ServerMainForm()
    {
      InitializeComponent();

      var test = new SalePointList();
      test.SalePoints = new List<SalePointRecordXml>{ new SalePointRecordXml() };
      
      // загрузка списка точек
      initializeSalePoints();
      salePointBindingSource.DataSource = salePoints;
      salePointBindingSource.ResetBindings(false);
    }

    // список ПР, который выводится в таблице
    private readonly List<SalePoint> salePoints = new List<SalePoint>();

    // загрузка списка точек осуществляется из базы АИС УРТ
    private void initializeSalePoints()
    {
      // загрузка информации из XML
      var salePointsXml = XmlHelper.Deserialize<SalePointList>(Path.Combine(Application.StartupPath, "SalePointIps.xml"));

      // загрузка информации из БД
      List<SalePointRecordSql> salePointsSql;
      List<Region> regions;
      List<Person> persons;
      List<Contact> contacts;
      using (var connAisurt = new SqlConnection(ConnectionWrapper.CreateLoginPassword(
        "192.168.1.202", "AISURT", "BlankPublishAgent", "BlankPublishAgent").ConnectionString))
      {
        connAisurt.Open();
        salePointsSql = loadList<SalePointRecordSql>(
          "select SubjectID ID, SubjectCode Code, SubjectName Name, AddressText Address, RegionCode Region from ViewSalePoint", connAisurt);
        regions = loadList<Region>(
          "select cast(Code as bigint) ID, Name from RoleRegion", connAisurt);
        persons = loadList<Person>(
          "select SubjectID, FName, IName, OName, Position from TrustPerson", connAisurt);
        contacts = loadList<Contact>(
          "select SubjectID, Phone, MobilePhone, FAX from ContactInformation", connAisurt);
      }

      // сведение всех данных воедино
      foreach (var xml in salePointsXml.SalePoints)
        salePoints.Add(SalePoint.LoadInfo(xml, salePointsSql, regions, persons, contacts, salePoints.FindAll(sp => sp.Code == xml.Code)));
    }

    private static List<T> loadList<T>(string queryText, SqlConnection connection)
      where T : IDatabaseInfo, new()
    {
      var list = new List<T>();

      var command = new SqlCommand(queryText, connection);
      using (var reader = command.ExecuteReader())
        while (reader.Read())
        {
          var obj = new T();
          obj.LoadProperties(reader);
          list.Add(obj);
        }

      return list;
    }

    #endregion

		#region Получение данных (обработчики кнопок)

		private void simpleButtonLog_Click(object sender, EventArgs e)
		{
			var sp = DevExpressHelper.GetSelectedRecord<SalePoint>(gridViewSalePoints);
			if (sp != null)
			{
				try
				{
					var clientService = Protocol.CreateClientProxy(sp.IP);
					LogForm.Show(this, sp, clientService.GetLog());
				}
				catch (Exception ex)
				{
					ErrorHelper.ShowError<ErrorForm>(null, ex);
				}
			}
		}

		private void simpleButtonVelcom_Click(object sender, EventArgs e)
		{
			var sp = DevExpressHelper.GetSelectedRecord<SalePoint>(gridViewSalePoints);
			if (sp != null)
			{
				try
				{
					var clientService = Protocol.CreateClientProxy(sp.IP);
					VelcomForm.Show(this, sp, clientService.GetVelcomParameters());
				}
				catch (Exception ex)
				{
					ErrorHelper.ShowError<ErrorForm>(null, ex);
				}
			}
		}

		private void simpleButtonServices_Click(object sender, EventArgs e)
		{
			var sp = DevExpressHelper.GetSelectedRecord<SalePoint>(gridViewSalePoints);
			if (sp != null)
			{
				try
				{
					var clientService = Protocol.CreateClientProxy(sp.IP);
					StatusForm.Show(this, sp, clientService.GetServicesStatus());
				}
				catch (Exception ex)
				{
					ErrorHelper.ShowError<ErrorForm>(null, ex);
				}
			}
		}

		private void simpleButtonHardware_Click(object sender, EventArgs e)
		{
			var sp = DevExpressHelper.GetSelectedRecord<SalePoint>(gridViewSalePoints);
			if (sp != null)
			{
				try
				{
					var clientService = Protocol.CreateClientProxy(sp.IP);
					SystemForm.Show(this, sp, clientService.GetSystemInfo());
				}
				catch (Exception ex)
				{
					ErrorHelper.ShowError<ErrorForm>(null, ex);
				}
			}
		}

		private void simpleButtonPrinter_Click(object sender, EventArgs e)
		{
			var sp = DevExpressHelper.GetSelectedRecord<SalePoint>(gridViewSalePoints);
			if (sp != null)
			{
				try
				{
					var clientService = Protocol.CreateClientProxy(sp.IP);
					PrintForm.Show(this, sp, clientService.GetSpooler());
				}
				catch (Exception ex)
				{
					ErrorHelper.ShowError<ErrorForm>(null, ex);
				}
			}
		}

		private void simpleButtonVersions_Click(object sender, EventArgs e)
		{
			var sp = DevExpressHelper.GetSelectedRecord<SalePoint>(gridViewSalePoints);
			if (sp != null)
			{
				try
				{
					var clientService = Protocol.CreateClientProxy(sp.IP);
					VersionForm.Show(this, sp, clientService.GetVersions());
				}
				catch (Exception ex)
				{
					ErrorHelper.ShowError<ErrorForm>(null, ex);
				}
			}
		}

		#endregion
  }
}