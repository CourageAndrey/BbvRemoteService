namespace AuxService.ClientConsole
{
  partial class ClientMainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientMainForm));
      this.xtraTabControl = new DevExpress.XtraTab.XtraTabControl();
      this.xtraTabPageSetings = new DevExpress.XtraTab.XtraTabPage();
      this.gridControlDatabases = new DevExpress.XtraGrid.GridControl();
      this.databaseWrapperBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.gridViewDatabases = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colDatabase = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemButtonEditDatabase = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
      this.colOptimize = new DevExpress.XtraGrid.Columns.GridColumn();
      this.simpleButtonClearBase = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonDeleteBase = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonAddBase = new DevExpress.XtraEditors.SimpleButton();
      this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.timeEdit1 = new DevExpress.XtraEditors.TimeEdit();
      this.configBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.buttonEditPath = new DevExpress.XtraEditors.ButtonEdit();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.spinEdit3 = new DevExpress.XtraEditors.SpinEdit();
      this.spinEdit2 = new DevExpress.XtraEditors.SpinEdit();
      this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
      this.simpleButtonClose = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonSave = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonDefault = new DevExpress.XtraEditors.SimpleButton();
      this.xtraTabPageLog = new DevExpress.XtraTab.XtraTabPage();
      this.logControl = new Sef.DX.LogControl();
      this.xtraTabPageControl = new DevExpress.XtraTab.XtraTabPage();
      this.simpleButtonStopService = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonStartService = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonRestartService = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonAddService = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonClearService = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonDeleteService = new DevExpress.XtraEditors.SimpleButton();
      this.gridControlServices = new DevExpress.XtraGrid.GridControl();
      this.serviceRecordBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.gridViewServices = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colStatusString = new DevExpress.XtraGrid.Columns.GridColumn();
      this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
      this.popupMenuDatabases = new DevExpress.XtraBars.PopupMenu(this.components);
      this.popupMenuServices = new DevExpress.XtraBars.PopupMenu(this.components);
      ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).BeginInit();
      this.xtraTabControl.SuspendLayout();
      this.xtraTabPageSetings.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridControlDatabases)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.databaseWrapperBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewDatabases)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditDatabase)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.configBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.buttonEditPath.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinEdit3.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinEdit2.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
      this.xtraTabPageLog.SuspendLayout();
      this.xtraTabPageControl.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridControlServices)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.serviceRecordBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewServices)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupMenuDatabases)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupMenuServices)).BeginInit();
      this.SuspendLayout();
      // 
      // xtraTabControl
      // 
      this.xtraTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.xtraTabControl.Location = new System.Drawing.Point(0, 0);
      this.xtraTabControl.Name = "xtraTabControl";
      this.xtraTabControl.SelectedTabPage = this.xtraTabPageSetings;
      this.xtraTabControl.Size = new System.Drawing.Size(892, 366);
      this.xtraTabControl.TabIndex = 0;
      this.xtraTabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPageSetings,
            this.xtraTabPageLog,
            this.xtraTabPageControl});
      // 
      // xtraTabPageSetings
      // 
      this.xtraTabPageSetings.Controls.Add(this.gridControlDatabases);
      this.xtraTabPageSetings.Controls.Add(this.simpleButtonClearBase);
      this.xtraTabPageSetings.Controls.Add(this.simpleButtonDeleteBase);
      this.xtraTabPageSetings.Controls.Add(this.simpleButtonAddBase);
      this.xtraTabPageSetings.Controls.Add(this.labelControl5);
      this.xtraTabPageSetings.Controls.Add(this.labelControl4);
      this.xtraTabPageSetings.Controls.Add(this.labelControl3);
      this.xtraTabPageSetings.Controls.Add(this.labelControl2);
      this.xtraTabPageSetings.Controls.Add(this.timeEdit1);
      this.xtraTabPageSetings.Controls.Add(this.buttonEditPath);
      this.xtraTabPageSetings.Controls.Add(this.labelControl1);
      this.xtraTabPageSetings.Controls.Add(this.spinEdit3);
      this.xtraTabPageSetings.Controls.Add(this.spinEdit2);
      this.xtraTabPageSetings.Controls.Add(this.spinEdit1);
      this.xtraTabPageSetings.Controls.Add(this.simpleButtonClose);
      this.xtraTabPageSetings.Controls.Add(this.simpleButtonSave);
      this.xtraTabPageSetings.Controls.Add(this.simpleButtonDefault);
      this.xtraTabPageSetings.Name = "xtraTabPageSetings";
      this.xtraTabPageSetings.Size = new System.Drawing.Size(800, 334);
      this.xtraTabPageSetings.Text = "Настройки";
      // 
      // gridControlDatabases
      // 
      this.gridControlDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.gridControlDatabases.DataSource = this.databaseWrapperBindingSource;
      this.gridControlDatabases.Location = new System.Drawing.Point(11, 32);
      this.gridControlDatabases.MainView = this.gridViewDatabases;
      this.gridControlDatabases.Name = "gridControlDatabases";
      this.gridControlDatabases.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEditDatabase});
      this.gridControlDatabases.Size = new System.Drawing.Size(782, 187);
      this.gridControlDatabases.TabIndex = 17;
      this.gridControlDatabases.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDatabases});
      // 
      // databaseWrapperBindingSource
      // 
      this.databaseWrapperBindingSource.DataSource = typeof(AuxService.Core.Settings.DatabaseWrapper);
      // 
      // gridViewDatabases
      // 
      this.gridViewDatabases.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatabase,
            this.colOptimize});
      this.gridViewDatabases.GridControl = this.gridControlDatabases;
      this.gridViewDatabases.Name = "gridViewDatabases";
      this.gridViewDatabases.OptionsView.ShowGroupPanel = false;
      // 
      // colDatabase
      // 
      this.colDatabase.Caption = "База данных";
      this.colDatabase.ColumnEdit = this.repositoryItemButtonEditDatabase;
      this.colDatabase.FieldName = "Database";
      this.colDatabase.Name = "colDatabase";
      this.colDatabase.Visible = true;
      this.colDatabase.VisibleIndex = 0;
      this.colDatabase.Width = 668;
      // 
      // repositoryItemButtonEditDatabase
      // 
      this.repositoryItemButtonEditDatabase.AutoHeight = false;
      this.repositoryItemButtonEditDatabase.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.repositoryItemButtonEditDatabase.Name = "repositoryItemButtonEditDatabase";
      this.repositoryItemButtonEditDatabase.ReadOnly = true;
      this.repositoryItemButtonEditDatabase.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
      this.repositoryItemButtonEditDatabase.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEditDatabase_ButtonClick);
      // 
      // colOptimize
      // 
      this.colOptimize.Caption = "Оптимизировать";
      this.colOptimize.FieldName = "Optimize";
      this.colOptimize.Name = "colOptimize";
      this.colOptimize.Visible = true;
      this.colOptimize.VisibleIndex = 1;
      this.colOptimize.Width = 137;
      // 
      // simpleButtonClearBase
      // 
      this.simpleButtonClearBase.Image = global::AuxService.ClientConsole.Properties.Resources.Clear;
      this.simpleButtonClearBase.Location = new System.Drawing.Point(223, 3);
      this.simpleButtonClearBase.Name = "simpleButtonClearBase";
      this.simpleButtonClearBase.Size = new System.Drawing.Size(100, 23);
      this.simpleButtonClearBase.TabIndex = 2;
      this.simpleButtonClearBase.Text = "Очистить";
      this.simpleButtonClearBase.Click += new System.EventHandler(this.simpleButtonClearBase_Click);
      // 
      // simpleButtonDeleteBase
      // 
      this.simpleButtonDeleteBase.Image = global::AuxService.ClientConsole.Properties.Resources.Delete;
      this.simpleButtonDeleteBase.Location = new System.Drawing.Point(117, 3);
      this.simpleButtonDeleteBase.Name = "simpleButtonDeleteBase";
      this.simpleButtonDeleteBase.Size = new System.Drawing.Size(100, 23);
      this.simpleButtonDeleteBase.TabIndex = 1;
      this.simpleButtonDeleteBase.Text = "Удалить";
      this.simpleButtonDeleteBase.Click += new System.EventHandler(this.simpleButtonDeleteBase_Click);
      // 
      // simpleButtonAddBase
      // 
      this.simpleButtonAddBase.Image = global::AuxService.ClientConsole.Properties.Resources.Add;
      this.simpleButtonAddBase.Location = new System.Drawing.Point(11, 3);
      this.simpleButtonAddBase.Name = "simpleButtonAddBase";
      this.simpleButtonAddBase.Size = new System.Drawing.Size(100, 23);
      this.simpleButtonAddBase.TabIndex = 0;
      this.simpleButtonAddBase.Text = "Добавить...";
      this.simpleButtonAddBase.Click += new System.EventHandler(this.simpleButtonAddBase_Click);
      // 
      // labelControl5
      // 
      this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.labelControl5.Location = new System.Drawing.Point(11, 228);
      this.labelControl5.Name = "labelControl5";
      this.labelControl5.Size = new System.Drawing.Size(81, 13);
      this.labelControl5.TabIndex = 4;
      this.labelControl5.Text = "Итоговая папка";
      // 
      // labelControl4
      // 
      this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.labelControl4.Location = new System.Drawing.Point(204, 280);
      this.labelControl4.Name = "labelControl4";
      this.labelControl4.Size = new System.Drawing.Size(73, 13);
      this.labelControl4.TabIndex = 12;
      this.labelControl4.Text = "Время запуска";
      // 
      // labelControl3
      // 
      this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.labelControl3.Location = new System.Drawing.Point(11, 254);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(64, 13);
      this.labelControl3.TabIndex = 6;
      this.labelControl3.Text = "Мин. сжатие";
      // 
      // labelControl2
      // 
      this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.labelControl2.Location = new System.Drawing.Point(11, 280);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(69, 13);
      this.labelControl2.TabIndex = 8;
      this.labelControl2.Text = "Макс. сжатие";
      // 
      // timeEdit1
      // 
      this.timeEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.timeEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.configBindingSource, "ScheduleTime", true));
      this.timeEdit1.EditValue = new System.DateTime(2012, 6, 27, 0, 0, 0, 0);
      this.timeEdit1.Location = new System.Drawing.Point(312, 277);
      this.timeEdit1.Name = "timeEdit1";
      this.timeEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.timeEdit1.Properties.Mask.EditMask = "t";
      this.timeEdit1.Size = new System.Drawing.Size(91, 20);
      this.timeEdit1.TabIndex = 13;
      // 
      // configBindingSource
      // 
      this.configBindingSource.DataSource = typeof(AuxService.Core.Settings.Config);
      // 
      // buttonEditPath
      // 
      this.buttonEditPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonEditPath.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configBindingSource, "OutputPath", true));
      this.buttonEditPath.Location = new System.Drawing.Point(102, 225);
      this.buttonEditPath.Name = "buttonEditPath";
      this.buttonEditPath.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.buttonEditPath.Size = new System.Drawing.Size(691, 20);
      this.buttonEditPath.TabIndex = 5;
      this.buttonEditPath.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.selectPathButtonClick);
      // 
      // labelControl1
      // 
      this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.labelControl1.Location = new System.Drawing.Point(204, 254);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(102, 13);
      this.labelControl1.TabIndex = 10;
      this.labelControl1.Text = "Задержка принтера";
      // 
      // spinEdit3
      // 
      this.spinEdit3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.spinEdit3.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.configBindingSource, "SpoolerTimer", true));
      this.spinEdit3.EditValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.spinEdit3.Location = new System.Drawing.Point(312, 251);
      this.spinEdit3.Name = "spinEdit3";
      this.spinEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.spinEdit3.Properties.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
      this.spinEdit3.Properties.IsFloatValue = false;
      this.spinEdit3.Properties.Mask.EditMask = "N00";
      this.spinEdit3.Properties.MaxValue = new decimal(new int[] {
            10000,
            0,
            0,
            0});
      this.spinEdit3.Properties.MinValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
      this.spinEdit3.Size = new System.Drawing.Size(91, 20);
      this.spinEdit3.TabIndex = 11;
      // 
      // spinEdit2
      // 
      this.spinEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.spinEdit2.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.configBindingSource, "CompressionRateMinimum", true));
      this.spinEdit2.EditValue = new decimal(new int[] {
            5,
            0,
            0,
            131072});
      this.spinEdit2.Location = new System.Drawing.Point(98, 251);
      this.spinEdit2.Name = "spinEdit2";
      this.spinEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.spinEdit2.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.spinEdit2.Properties.MaxValue = new decimal(new int[] {
            95,
            0,
            0,
            131072});
      this.spinEdit2.Properties.MinValue = new decimal(new int[] {
            5,
            0,
            0,
            131072});
      this.spinEdit2.Size = new System.Drawing.Size(100, 20);
      this.spinEdit2.TabIndex = 7;
      // 
      // spinEdit1
      // 
      this.spinEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.spinEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.configBindingSource, "CompressionRateMaximum", true));
      this.spinEdit1.EditValue = new decimal(new int[] {
            5,
            0,
            0,
            131072});
      this.spinEdit1.Location = new System.Drawing.Point(98, 277);
      this.spinEdit1.Name = "spinEdit1";
      this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.spinEdit1.Properties.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
      this.spinEdit1.Properties.MaxValue = new decimal(new int[] {
            95,
            0,
            0,
            131072});
      this.spinEdit1.Properties.MinValue = new decimal(new int[] {
            5,
            0,
            0,
            131072});
      this.spinEdit1.Size = new System.Drawing.Size(100, 20);
      this.spinEdit1.TabIndex = 9;
      // 
      // simpleButtonClose
      // 
      this.simpleButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.simpleButtonClose.Image = global::AuxService.ClientConsole.Properties.Resources.Exit;
      this.simpleButtonClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
      this.simpleButtonClose.Location = new System.Drawing.Point(683, 303);
      this.simpleButtonClose.Name = "simpleButtonClose";
      this.simpleButtonClose.Size = new System.Drawing.Size(110, 24);
      this.simpleButtonClose.TabIndex = 16;
      this.simpleButtonClose.Text = "Закрыть";
      this.simpleButtonClose.Click += new System.EventHandler(this.simpleButtonClose_Click);
      // 
      // simpleButtonSave
      // 
      this.simpleButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.simpleButtonSave.Image = global::AuxService.ClientConsole.Properties.Resources.Save;
      this.simpleButtonSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
      this.simpleButtonSave.Location = new System.Drawing.Point(567, 303);
      this.simpleButtonSave.Name = "simpleButtonSave";
      this.simpleButtonSave.Size = new System.Drawing.Size(110, 24);
      this.simpleButtonSave.TabIndex = 15;
      this.simpleButtonSave.Text = "Сохранить";
      this.simpleButtonSave.Click += new System.EventHandler(this.simpleButtonSave_Click);
      // 
      // simpleButtonDefault
      // 
      this.simpleButtonDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.simpleButtonDefault.Image = global::AuxService.ClientConsole.Properties.Resources.Default;
      this.simpleButtonDefault.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
      this.simpleButtonDefault.Location = new System.Drawing.Point(451, 303);
      this.simpleButtonDefault.Name = "simpleButtonDefault";
      this.simpleButtonDefault.Size = new System.Drawing.Size(110, 24);
      this.simpleButtonDefault.TabIndex = 14;
      this.simpleButtonDefault.Text = "По умолчанию";
      this.simpleButtonDefault.Click += new System.EventHandler(this.simpleButtonDefault_Click);
      // 
      // xtraTabPageLog
      // 
      this.xtraTabPageLog.Controls.Add(this.logControl);
      this.xtraTabPageLog.Name = "xtraTabPageLog";
      this.xtraTabPageLog.Size = new System.Drawing.Size(886, 338);
      this.xtraTabPageLog.Text = "Журнал";
      // 
      // logControl
      // 
      this.logControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.logControl.Location = new System.Drawing.Point(0, 0);
      this.logControl.MinimumSize = new System.Drawing.Size(400, 200);
      this.logControl.Name = "logControl";
      this.logControl.Size = new System.Drawing.Size(886, 338);
      this.logControl.TabIndex = 0;
      // 
      // xtraTabPageControl
      // 
      this.xtraTabPageControl.Controls.Add(this.simpleButtonStopService);
      this.xtraTabPageControl.Controls.Add(this.simpleButtonStartService);
      this.xtraTabPageControl.Controls.Add(this.simpleButtonRestartService);
      this.xtraTabPageControl.Controls.Add(this.simpleButtonAddService);
      this.xtraTabPageControl.Controls.Add(this.simpleButtonClearService);
      this.xtraTabPageControl.Controls.Add(this.simpleButtonDeleteService);
      this.xtraTabPageControl.Controls.Add(this.gridControlServices);
      this.xtraTabPageControl.Name = "xtraTabPageControl";
      this.xtraTabPageControl.Size = new System.Drawing.Size(886, 338);
      this.xtraTabPageControl.Text = "Службы";
      // 
      // simpleButtonStopService
      // 
      this.simpleButtonStopService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.simpleButtonStopService.Image = global::AuxService.ClientConsole.Properties.Resources.Stop;
      this.simpleButtonStopService.Location = new System.Drawing.Point(633, 308);
      this.simpleButtonStopService.Name = "simpleButtonStopService";
      this.simpleButtonStopService.Size = new System.Drawing.Size(120, 23);
      this.simpleButtonStopService.TabIndex = 8;
      this.simpleButtonStopService.Text = "Остановить";
      this.simpleButtonStopService.Click += new System.EventHandler(this.simpleButtonStopService_Click);
      // 
      // simpleButtonStartService
      // 
      this.simpleButtonStartService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.simpleButtonStartService.Image = global::AuxService.ClientConsole.Properties.Resources.Start;
      this.simpleButtonStartService.Location = new System.Drawing.Point(507, 308);
      this.simpleButtonStartService.Name = "simpleButtonStartService";
      this.simpleButtonStartService.Size = new System.Drawing.Size(120, 23);
      this.simpleButtonStartService.TabIndex = 7;
      this.simpleButtonStartService.Text = "Запустить";
      this.simpleButtonStartService.Click += new System.EventHandler(this.simpleButtonStartService_Click);
      // 
      // simpleButtonRestartService
      // 
      this.simpleButtonRestartService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.simpleButtonRestartService.Image = global::AuxService.ClientConsole.Properties.Resources.Restart;
      this.simpleButtonRestartService.Location = new System.Drawing.Point(759, 308);
      this.simpleButtonRestartService.Name = "simpleButtonRestartService";
      this.simpleButtonRestartService.Size = new System.Drawing.Size(120, 23);
      this.simpleButtonRestartService.TabIndex = 9;
      this.simpleButtonRestartService.Text = "Перезапустить";
      this.simpleButtonRestartService.Click += new System.EventHandler(this.simpleButtonRestartService_Click);
      // 
      // simpleButtonAddService
      // 
      this.simpleButtonAddService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.simpleButtonAddService.Image = global::AuxService.ClientConsole.Properties.Resources.Add;
      this.simpleButtonAddService.Location = new System.Drawing.Point(3, 308);
      this.simpleButtonAddService.Name = "simpleButtonAddService";
      this.simpleButtonAddService.Size = new System.Drawing.Size(100, 23);
      this.simpleButtonAddService.TabIndex = 1;
      this.simpleButtonAddService.Text = "Добавить...";
      this.simpleButtonAddService.Click += new System.EventHandler(this.simpleButtonAddService_Click);
      // 
      // simpleButtonClearService
      // 
      this.simpleButtonClearService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.simpleButtonClearService.Image = global::AuxService.ClientConsole.Properties.Resources.Clear;
      this.simpleButtonClearService.Location = new System.Drawing.Point(215, 308);
      this.simpleButtonClearService.Name = "simpleButtonClearService";
      this.simpleButtonClearService.Size = new System.Drawing.Size(100, 23);
      this.simpleButtonClearService.TabIndex = 3;
      this.simpleButtonClearService.Text = "Очистить";
      this.simpleButtonClearService.Click += new System.EventHandler(this.simpleButtonClearService_Click);
      // 
      // simpleButtonDeleteService
      // 
      this.simpleButtonDeleteService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.simpleButtonDeleteService.Image = global::AuxService.ClientConsole.Properties.Resources.Delete;
      this.simpleButtonDeleteService.Location = new System.Drawing.Point(109, 308);
      this.simpleButtonDeleteService.Name = "simpleButtonDeleteService";
      this.simpleButtonDeleteService.Size = new System.Drawing.Size(100, 23);
      this.simpleButtonDeleteService.TabIndex = 2;
      this.simpleButtonDeleteService.Text = "Удалить";
      this.simpleButtonDeleteService.Click += new System.EventHandler(this.simpleButtonDeleteService_Click);
      // 
      // gridControlServices
      // 
      this.gridControlServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.gridControlServices.DataSource = this.serviceRecordBindingSource;
      this.gridControlServices.Location = new System.Drawing.Point(0, 0);
      this.gridControlServices.MainView = this.gridViewServices;
      this.gridControlServices.Name = "gridControlServices";
      this.gridControlServices.Size = new System.Drawing.Size(886, 302);
      this.gridControlServices.TabIndex = 0;
      this.gridControlServices.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewServices});
      // 
      // gridViewServices
      // 
      this.gridViewServices.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colServiceName,
            this.colDisplayName,
            this.colStatusString});
      this.gridViewServices.GridControl = this.gridControlServices;
      this.gridViewServices.Name = "gridViewServices";
      this.gridViewServices.OptionsView.ColumnAutoWidth = false;
      this.gridViewServices.OptionsView.ShowGroupPanel = false;
      this.gridViewServices.OptionsView.ShowIndicator = false;
      // 
      // colServiceName
      // 
      this.colServiceName.Caption = "Служба";
      this.colServiceName.FieldName = "ServiceName";
      this.colServiceName.Name = "colServiceName";
      this.colServiceName.OptionsColumn.AllowEdit = false;
      this.colServiceName.OptionsColumn.ReadOnly = true;
      this.colServiceName.Visible = true;
      this.colServiceName.VisibleIndex = 0;
      this.colServiceName.Width = 154;
      // 
      // colDisplayName
      // 
      this.colDisplayName.Caption = "Описание";
      this.colDisplayName.FieldName = "DisplayName";
      this.colDisplayName.Name = "colDisplayName";
      this.colDisplayName.OptionsColumn.AllowEdit = false;
      this.colDisplayName.OptionsColumn.ReadOnly = true;
      this.colDisplayName.Visible = true;
      this.colDisplayName.VisibleIndex = 2;
      this.colDisplayName.Width = 283;
      // 
      // colStatusString
      // 
      this.colStatusString.Caption = "Состояние";
      this.colStatusString.FieldName = "StatusString";
      this.colStatusString.Name = "colStatusString";
      this.colStatusString.OptionsColumn.AllowEdit = false;
      this.colStatusString.OptionsColumn.ReadOnly = true;
      this.colStatusString.Visible = true;
      this.colStatusString.VisibleIndex = 1;
      this.colStatusString.Width = 112;
      // 
      // folderBrowserDialog
      // 
      this.folderBrowserDialog.Description = "Выберите путь...";
      // 
      // popupMenuDatabases
      // 
      this.popupMenuDatabases.Name = "popupMenuDatabases";
      // 
      // popupMenuServices
      // 
      this.popupMenuServices.Name = "popupMenuServices";
      // 
      // ClientMainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(892, 366);
      this.Controls.Add(this.xtraTabControl);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(800, 350);
      this.Name = "ClientMainForm";
      this.Text = "Вспомогательный сервис - клиент - настройка";
      ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl)).EndInit();
      this.xtraTabControl.ResumeLayout(false);
      this.xtraTabPageSetings.ResumeLayout(false);
      this.xtraTabPageSetings.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridControlDatabases)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.databaseWrapperBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewDatabases)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEditDatabase)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.configBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.buttonEditPath.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinEdit3.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinEdit2.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
      this.xtraTabPageLog.ResumeLayout(false);
      this.xtraTabPageControl.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridControlServices)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.serviceRecordBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewServices)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupMenuDatabases)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.popupMenuServices)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraTab.XtraTabControl xtraTabControl;
    private DevExpress.XtraTab.XtraTabPage xtraTabPageSetings;
    private DevExpress.XtraTab.XtraTabPage xtraTabPageLog;
    private DevExpress.XtraTab.XtraTabPage xtraTabPageControl;
    private DevExpress.XtraGrid.GridControl gridControlServices;
    private DevExpress.XtraGrid.Views.Grid.GridView gridViewServices;
    private DevExpress.XtraGrid.Columns.GridColumn colServiceName;
    private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
    private DevExpress.XtraGrid.Columns.GridColumn colStatusString;
    private DevExpress.XtraEditors.SimpleButton simpleButtonClose;
    private DevExpress.XtraEditors.SimpleButton simpleButtonSave;
    private DevExpress.XtraEditors.SimpleButton simpleButtonDefault;
    private System.Windows.Forms.BindingSource serviceRecordBindingSource;
    private Sef.DX.LogControl logControl;
    private DevExpress.XtraEditors.SpinEdit spinEdit3;
    private DevExpress.XtraEditors.SpinEdit spinEdit2;
    private DevExpress.XtraEditors.SpinEdit spinEdit1;
    private DevExpress.XtraEditors.ButtonEdit buttonEditPath;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.LabelControl labelControl5;
    private DevExpress.XtraEditors.LabelControl labelControl4;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.TimeEdit timeEdit1;
    private System.Windows.Forms.BindingSource configBindingSource;
    private System.Windows.Forms.BindingSource databaseWrapperBindingSource;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
    private DevExpress.XtraBars.PopupMenu popupMenuDatabases;
    private DevExpress.XtraBars.PopupMenu popupMenuServices;
    private DevExpress.XtraEditors.SimpleButton simpleButtonAddService;
    private DevExpress.XtraEditors.SimpleButton simpleButtonClearService;
    private DevExpress.XtraEditors.SimpleButton simpleButtonDeleteService;
    private DevExpress.XtraEditors.SimpleButton simpleButtonDeleteBase;
    private DevExpress.XtraEditors.SimpleButton simpleButtonAddBase;
    private DevExpress.XtraEditors.SimpleButton simpleButtonClearBase;
    private DevExpress.XtraEditors.SimpleButton simpleButtonStopService;
    private DevExpress.XtraEditors.SimpleButton simpleButtonStartService;
    private DevExpress.XtraEditors.SimpleButton simpleButtonRestartService;
    private DevExpress.XtraGrid.GridControl gridControlDatabases;
    private DevExpress.XtraGrid.Views.Grid.GridView gridViewDatabases;
    private DevExpress.XtraGrid.Columns.GridColumn colDatabase;
    private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEditDatabase;
    private DevExpress.XtraGrid.Columns.GridColumn colOptimize;
  }
}