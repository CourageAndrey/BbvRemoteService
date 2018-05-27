using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AuxService.Core.Helpers;
using AuxService.Core.Service;
using AuxService.Core.Settings;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Sef.DX;
using Sef.Sql;
using Sef.Utility.Database;

namespace AuxService.ClientConsole
{
  /// <summary>
  /// Главная форма консоли клиента.
  /// </summary>
  public partial class ClientMainForm : XtraForm
  {
    #region Инициализация

    /// <summary>
    /// ctor.
    /// </summary>
    public ClientMainForm()
    {
      InitializeComponent();

      // включение SQL-доступа к данным
      DatabaseHelper.RegisterHelper(new DatabaseHelperSql());

      // чтение настроек
      Config.LoadOrCreate();
      // загрузка таблицы журнала
      logControl.LoadFromFolder(Config.LogPath);

      // пометка цветом состояний служб
      DevExpressHelper.CreateConditionExpression(gridViewServices, colStatusString, "![IsInstalled]", Color.Yellow);
      DevExpressHelper.CreateConditionExpression(gridViewServices, colStatusString, "[IsStopped]", Color.Red);
      DevExpressHelper.CreateConditionExpression(gridViewServices, colStatusString, "[IsInstalled] && ![IsStopped]", Color.Lime);
      
      // загрузка настроек
      refreshSettings();
    }

    private void refreshSettings()
    {
      // общие настройки
      configBindingSource.DataSource = Config.Instance;
      configBindingSource.ResetBindings(false);

      // подключения к БД
      databaseWrapperBindingSource.DataSource = Config.Instance.Databases;
      databaseWrapperBindingSource.ResetBindings(false);

      // службы
      refreshServices();
    }

    private void refreshServices()
    {
      var services = new List<ServiceRecord>();
      foreach (var service in Config.Instance.ControlledServices)
        services.Add(new ServiceRecord(service));
      services.ForEach(s => s.ForceRefresh());
      serviceRecordBindingSource.DataSource = services;
      serviceRecordBindingSource.ResetBindings(false);
    }
    
    #endregion

    #region Обработчики событий

    #region Настройки

    private void simpleButtonClose_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void simpleButtonSave_Click(object sender, EventArgs e)
    {
      Config.Save();
    }

    private void simpleButtonDefault_Click(object sender, EventArgs e)
    {
      Config.Instance.InitializeDefault();
      refreshSettings();
    }

    #endregion

    private void selectPathButtonClick(object sender, ButtonPressedEventArgs e)
    {
      folderBrowserDialog.SelectedPath = buttonEditPath.Text;
      if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
        buttonEditPath.Text = folderBrowserDialog.SelectedPath;
    }

    #region Службы

    private void simpleButtonAddService_Click(object sender, EventArgs e)
    {
      var service = SelectServiceDialog.Execute(this);
      if (service != null)
      {
        Config.Instance.ControlledServices.Add(service.ServiceName);
        refreshServices();
      }
    }

    private void simpleButtonDeleteService_Click(object sender, EventArgs e)
    {
      var service = DevExpressHelper.GetSelectedRecord<ServiceRecord>(gridViewServices);
      if (service == null)
        return;
      Config.Instance.ControlledServices.Remove(service.ServiceName);
      refreshServices();
    }

    private void simpleButtonClearService_Click(object sender, EventArgs e)
    {
      if (XtraMessageBox.Show(this, "Очистить список?", "Удаление записей о службах", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      Config.Instance.ControlledServices.Clear();
      refreshServices();
    }

    private void simpleButtonStartService_Click(object sender, EventArgs e)
    {
      controlService(service => service.Start(this));
    }

    private void simpleButtonStopService_Click(object sender, EventArgs e)
    {
      controlService(service => service.Stop(this));
    }

    private void simpleButtonRestartService_Click(object sender, EventArgs e)
    {
      controlService(service => service.Restart(this));
    }

    private void repositoryItemButtonEditDatabase_ButtonClick(object sender, ButtonPressedEventArgs e)
    {
      var database = DevExpressHelper.GetSelectedRecord<DatabaseWrapper>(gridViewDatabases);
      database.Database = ConnectionStringDialog.Execute(this, database.Database);
      databaseWrapperBindingSource.ResetBindings(false);
    }

    #endregion

    #region Управление базами данных

    private void simpleButtonAddBase_Click(object sender, EventArgs e)
    {
      var newBase = new DatabaseWrapper(new ConnectionWrapper(), false);
      Config.Instance.Databases.Add(newBase);
      databaseWrapperBindingSource.ResetBindings(false);
    }

    private void simpleButtonDeleteBase_Click(object sender, EventArgs e)
    {
      var database = DevExpressHelper.GetSelectedRecord<DatabaseWrapper>(gridViewDatabases);
      if (database == null)
        return;
      Config.Instance.Databases.Remove(database);
      databaseWrapperBindingSource.ResetBindings(false);
    }

    private void simpleButtonClearBase_Click(object sender, EventArgs e)
    {
      if (XtraMessageBox.Show(this, "Очистить список?", "Удаление подключений к БД", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
        return;
      Config.Instance.Databases.Clear();
      databaseWrapperBindingSource.ResetBindings(false);
    }

    #endregion

    #endregion

    private void controlService(Action<ServiceRecord> routine)
    {
      var service = DevExpressHelper.GetSelectedRecord<ServiceRecord>(gridViewServices);
      if (service == null)
        return;
      if (service.IsInstalled)
      {
        routine.Invoke(service);
        refreshServices();
      }
      else
        XtraMessageBox.Show(this, "Служба не установлена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
  }
}