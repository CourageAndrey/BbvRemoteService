using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;using System.Windows.Forms;
using AuxService.Core.SalePoints;
using AuxService.Core.SalePoints.Forms;
using AuxService.Core.SalePoints.Queries;
using AuxService.Core.Transfer;
using DevExpress.XtraEditors;
using Sef.DX;
using Sef.Sql;
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

      // включение SQL-доступа к данным
      DatabaseHelper.RegisterHelper(new DatabaseHelperSql());
      
      // загрузка списка точек
      initializeSalePoints();
      salePointBindingSource.DataSource = salePoints;
      salePointBindingSource.ResetBindings(false);

      // ожидание сетевых пакетов, отправленных по запросу клиентами
      var server = new Server();
      server.Receive += server_Receive;
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
        sp.Request(this, Protocol.GetLogsSign);
    }

    private void simpleButtonVelcom_Click(object sender, EventArgs e)
    {
      var sp = DevExpressHelper.GetSelectedRecord<SalePoint>(gridViewSalePoints);
      if (sp != null)
        sp.Request(this, Protocol.GetTrafficSign);
    }

    private void simpleButtonServices_Click(object sender, EventArgs e)
    {
      var sp = DevExpressHelper.GetSelectedRecord<SalePoint>(gridViewSalePoints);
      if (sp != null)
        sp.Request(this, Protocol.GetStatusSign);
    }

    private void simpleButtonHardware_Click(object sender, EventArgs e)
    {
      var sp = DevExpressHelper.GetSelectedRecord<SalePoint>(gridViewSalePoints);
      if (sp != null)
        sp.Request(this, Protocol.GetHardSign);
    }

    private void simpleButtonPrinter_Click(object sender, EventArgs e)
    {
      var sp = DevExpressHelper.GetSelectedRecord<SalePoint>(gridViewSalePoints);
      if (sp != null)
        sp.Request(this, Protocol.GetPrintedSign);
    }

    private void simpleButtonVersions_Click(object sender, EventArgs e)
    {
      var sp = DevExpressHelper.GetSelectedRecord<SalePoint>(gridViewSalePoints);
      if (sp != null)
        sp.Request(this, Protocol.GetVersionsSign);
    }

    #endregion

    #region Разбор гответов от клиентов

    // обработчик ответов от клиентов
    private void server_Receive(object sender, ServerEventArgs e)
    {
      Invoke(new ShowForm(showForm), e.Packet);
    }

    private delegate void ShowForm(object p);

    private void showForm(object p)
    {
      var packet = p as Packet;
      string sign = packet.Message.Substring(0, 5);
      string message = packet.Message.Substring(5);
      var salePoint = salePoints.First(sp => sp.Code == packet.SenderCode);
      switch (sign)
      {
        case Protocol.GetHardSign:
          SystemForm.Show(this, salePoint, XmlHelper.DeserializeXml<SystemInfo>(message));
          break;
        case Protocol.GetLogsSign:
          LogForm.Show(this, salePoint, XmlHelper.DeserializeXml<LogInfoList>(message));
          break;
        case Protocol.GetPrintedSign:
          PrintForm.Show(this, salePoint, XmlHelper.DeserializeXml<PrintInfoList>(message));
          break;
        case Protocol.GetStatusSign:
          StatusForm.Show(this, salePoint, XmlHelper.DeserializeXml<StatusInfoList>(message));
          break;
        case Protocol.GetTrafficSign:
          VelcomForm.Show(this, salePoint, XmlHelper.DeserializeXml<VelcomInfoList>(message));
          break;
        case Protocol.GetVersionsSign:
          VersionForm.Show(this, salePoint, XmlHelper.DeserializeXml<VersionInfoList>(message));
          break;
        default:
          throw new NotSupportedException();
      }
    }

    #endregion
  }
}