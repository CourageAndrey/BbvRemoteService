namespace AuxService.ServerConsole
{
  partial class ServerMainForm
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
      DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
      DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
      DevExpress.XtraGrid.GridLevelNode gridLevelNode3 = new DevExpress.XtraGrid.GridLevelNode();
      DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition1 = new DevExpress.XtraGrid.StyleFormatCondition();
      DevExpress.XtraGrid.StyleFormatCondition styleFormatCondition2 = new DevExpress.XtraGrid.StyleFormatCondition();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerMainForm));
      this.gridViewAdresses = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.gridControl = new DevExpress.XtraGrid.GridControl();
      this.salePointBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.gridViewContacts = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.gridViewTrustPersons = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.gridViewSalePoints = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colRegion = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colIP = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colAUX = new DevExpress.XtraGrid.Columns.GridColumn();
      this.groupControlQueries = new DevExpress.XtraEditors.GroupControl();
      this.simpleButtonVersions = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonServices = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonHardware = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonPrinter = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonVelcom = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonLog = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewAdresses)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.salePointBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewContacts)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewTrustPersons)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewSalePoints)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.groupControlQueries)).BeginInit();
      this.groupControlQueries.SuspendLayout();
      this.SuspendLayout();
      // 
      // gridViewAdresses
      // 
      this.gridViewAdresses.GridControl = this.gridControl;
      this.gridViewAdresses.Name = "gridViewAdresses";
      this.gridViewAdresses.OptionsBehavior.Editable = false;
      this.gridViewAdresses.OptionsBehavior.ReadOnly = true;
      this.gridViewAdresses.OptionsView.ShowColumnHeaders = false;
      this.gridViewAdresses.OptionsView.ShowGroupPanel = false;
      this.gridViewAdresses.OptionsView.ShowIndicator = false;
      this.gridViewAdresses.ViewCaption = "Адрес";
      // 
      // gridControl
      // 
      this.gridControl.DataSource = this.salePointBindingSource;
      this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
      gridLevelNode1.LevelTemplate = this.gridViewAdresses;
      gridLevelNode1.RelationName = "Address";
      gridLevelNode2.LevelTemplate = this.gridViewContacts;
      gridLevelNode2.RelationName = "Contacts";
      gridLevelNode3.LevelTemplate = this.gridViewTrustPersons;
      gridLevelNode3.RelationName = "Persons";
      this.gridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1,
            gridLevelNode2,
            gridLevelNode3});
      this.gridControl.Location = new System.Drawing.Point(0, 0);
      this.gridControl.MainView = this.gridViewSalePoints;
      this.gridControl.Name = "gridControl";
      this.gridControl.Size = new System.Drawing.Size(584, 412);
      this.gridControl.TabIndex = 0;
      this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewContacts,
            this.gridViewTrustPersons,
            this.gridViewSalePoints,
            this.gridViewAdresses});
      // 
      // salePointBindingSource
      // 
      this.salePointBindingSource.DataSource = typeof(AuxService.Core.SalePoints.SalePoint);
      // 
      // gridViewContacts
      // 
      this.gridViewContacts.GridControl = this.gridControl;
      this.gridViewContacts.Name = "gridViewContacts";
      this.gridViewContacts.OptionsBehavior.Editable = false;
      this.gridViewContacts.OptionsBehavior.ReadOnly = true;
      this.gridViewContacts.OptionsView.ShowColumnHeaders = false;
      this.gridViewContacts.OptionsView.ShowGroupPanel = false;
      this.gridViewContacts.OptionsView.ShowIndicator = false;
      this.gridViewContacts.ViewCaption = "Контактные данные";
      // 
      // gridViewTrustPersons
      // 
      this.gridViewTrustPersons.GridControl = this.gridControl;
      this.gridViewTrustPersons.Name = "gridViewTrustPersons";
      this.gridViewTrustPersons.OptionsBehavior.Editable = false;
      this.gridViewTrustPersons.OptionsBehavior.ReadOnly = true;
      this.gridViewTrustPersons.OptionsView.ShowColumnHeaders = false;
      this.gridViewTrustPersons.OptionsView.ShowGroupPanel = false;
      this.gridViewTrustPersons.OptionsView.ShowIndicator = false;
      this.gridViewTrustPersons.ViewCaption = "Продавцы";
      // 
      // gridViewSalePoints
      // 
      this.gridViewSalePoints.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colName,
            this.colRegion,
            this.colIP,
            this.colAUX});
      styleFormatCondition1.Appearance.BackColor = System.Drawing.Color.Red;
      styleFormatCondition1.Appearance.Options.UseBackColor = true;
      styleFormatCondition1.ApplyToRow = true;
      styleFormatCondition1.Column = this.colAUX;
      styleFormatCondition1.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
      styleFormatCondition1.Value1 = false;
      styleFormatCondition2.Appearance.BackColor = System.Drawing.Color.Lime;
      styleFormatCondition2.Appearance.Options.UseBackColor = true;
      styleFormatCondition2.ApplyToRow = true;
      styleFormatCondition2.Column = this.colAUX;
      styleFormatCondition2.Condition = DevExpress.XtraGrid.FormatConditionEnum.Equal;
      styleFormatCondition2.Value1 = true;
      this.gridViewSalePoints.FormatConditions.AddRange(new DevExpress.XtraGrid.StyleFormatCondition[] {
            styleFormatCondition1,
            styleFormatCondition2});
      this.gridViewSalePoints.GridControl = this.gridControl;
      this.gridViewSalePoints.GroupCount = 1;
      this.gridViewSalePoints.LevelIndent = 0;
      this.gridViewSalePoints.Name = "gridViewSalePoints";
      this.gridViewSalePoints.OptionsBehavior.AutoExpandAllGroups = true;
      this.gridViewSalePoints.OptionsView.ColumnAutoWidth = false;
      this.gridViewSalePoints.OptionsView.ShowIndicator = false;
      this.gridViewSalePoints.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colRegion, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCode, DevExpress.Data.ColumnSortOrder.Ascending)});
      // 
      // colCode
      // 
      this.colCode.Caption = "Код";
      this.colCode.FieldName = "Code";
      this.colCode.Name = "colCode";
      this.colCode.OptionsColumn.AllowEdit = false;
      this.colCode.OptionsColumn.ReadOnly = true;
      this.colCode.Visible = true;
      this.colCode.VisibleIndex = 0;
      this.colCode.Width = 83;
      // 
      // colName
      // 
      this.colName.Caption = "Пункт реализации";
      this.colName.FieldName = "Name";
      this.colName.Name = "colName";
      this.colName.OptionsColumn.AllowEdit = false;
      this.colName.OptionsColumn.ReadOnly = true;
      this.colName.Visible = true;
      this.colName.VisibleIndex = 1;
      this.colName.Width = 286;
      // 
      // colRegion
      // 
      this.colRegion.Caption = "Регион";
      this.colRegion.FieldName = "Region";
      this.colRegion.Name = "colRegion";
      this.colRegion.OptionsColumn.ReadOnly = true;
      // 
      // colIP
      // 
      this.colIP.Caption = "IP-адрес";
      this.colIP.FieldName = "IP";
      this.colIP.Name = "colIP";
      this.colIP.OptionsColumn.AllowEdit = false;
      this.colIP.OptionsColumn.ReadOnly = true;
      this.colIP.Visible = true;
      this.colIP.VisibleIndex = 2;
      this.colIP.Width = 146;
      // 
      // colAUX
      // 
      this.colAUX.FieldName = "AUX";
      this.colAUX.Name = "colAUX";
      // 
      // groupControlQueries
      // 
      this.groupControlQueries.Controls.Add(this.simpleButtonVersions);
      this.groupControlQueries.Controls.Add(this.simpleButtonServices);
      this.groupControlQueries.Controls.Add(this.simpleButtonHardware);
      this.groupControlQueries.Controls.Add(this.simpleButtonPrinter);
      this.groupControlQueries.Controls.Add(this.simpleButtonVelcom);
      this.groupControlQueries.Controls.Add(this.simpleButtonLog);
      this.groupControlQueries.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.groupControlQueries.Location = new System.Drawing.Point(0, 412);
      this.groupControlQueries.Name = "groupControlQueries";
      this.groupControlQueries.Size = new System.Drawing.Size(584, 94);
      this.groupControlQueries.TabIndex = 1;
      this.groupControlQueries.Text = "Запросы";
      // 
      // simpleButtonVersions
      // 
      this.simpleButtonVersions.Image = global::AuxService.ServerConsole.Properties.Resources.GetVersions;
      this.simpleButtonVersions.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
      this.simpleButtonVersions.Location = new System.Drawing.Point(257, 55);
      this.simpleButtonVersions.Name = "simpleButtonVersions";
      this.simpleButtonVersions.Size = new System.Drawing.Size(120, 24);
      this.simpleButtonVersions.TabIndex = 5;
      this.simpleButtonVersions.Text = "Версии ПО";
      this.simpleButtonVersions.Click += new System.EventHandler(this.simpleButtonVersions_Click);
      // 
      // simpleButtonServices
      // 
      this.simpleButtonServices.Image = global::AuxService.ServerConsole.Properties.Resources.Services;
      this.simpleButtonServices.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
      this.simpleButtonServices.Location = new System.Drawing.Point(257, 24);
      this.simpleButtonServices.Name = "simpleButtonServices";
      this.simpleButtonServices.Size = new System.Drawing.Size(120, 24);
      this.simpleButtonServices.TabIndex = 2;
      this.simpleButtonServices.Text = "Состояние служб";
      this.simpleButtonServices.Click += new System.EventHandler(this.simpleButtonServices_Click);
      // 
      // simpleButtonHardware
      // 
      this.simpleButtonHardware.Image = global::AuxService.ServerConsole.Properties.Resources.GetHard;
      this.simpleButtonHardware.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
      this.simpleButtonHardware.Location = new System.Drawing.Point(5, 55);
      this.simpleButtonHardware.Name = "simpleButtonHardware";
      this.simpleButtonHardware.Size = new System.Drawing.Size(120, 24);
      this.simpleButtonHardware.TabIndex = 3;
      this.simpleButtonHardware.Text = "Оборудование";
      this.simpleButtonHardware.Click += new System.EventHandler(this.simpleButtonHardware_Click);
      // 
      // simpleButtonPrinter
      // 
      this.simpleButtonPrinter.Image = global::AuxService.ServerConsole.Properties.Resources.Printer;
      this.simpleButtonPrinter.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
      this.simpleButtonPrinter.Location = new System.Drawing.Point(131, 54);
      this.simpleButtonPrinter.Name = "simpleButtonPrinter";
      this.simpleButtonPrinter.Size = new System.Drawing.Size(120, 24);
      this.simpleButtonPrinter.TabIndex = 4;
      this.simpleButtonPrinter.Text = "Журнал принтера";
      this.simpleButtonPrinter.Click += new System.EventHandler(this.simpleButtonPrinter_Click);
      // 
      // simpleButtonVelcom
      // 
      this.simpleButtonVelcom.Image = global::AuxService.ServerConsole.Properties.Resources.Velcom;
      this.simpleButtonVelcom.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
      this.simpleButtonVelcom.Location = new System.Drawing.Point(131, 24);
      this.simpleButtonVelcom.Name = "simpleButtonVelcom";
      this.simpleButtonVelcom.Size = new System.Drawing.Size(120, 24);
      this.simpleButtonVelcom.TabIndex = 1;
      this.simpleButtonVelcom.Text = "Трафик Velcom";
      this.simpleButtonVelcom.Click += new System.EventHandler(this.simpleButtonVelcom_Click);
      // 
      // simpleButtonLog
      // 
      this.simpleButtonLog.Image = global::AuxService.ServerConsole.Properties.Resources.GetLogs;
      this.simpleButtonLog.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
      this.simpleButtonLog.Location = new System.Drawing.Point(5, 25);
      this.simpleButtonLog.Name = "simpleButtonLog";
      this.simpleButtonLog.Size = new System.Drawing.Size(120, 24);
      this.simpleButtonLog.TabIndex = 0;
      this.simpleButtonLog.Text = "Журнал работы";
      this.simpleButtonLog.Click += new System.EventHandler(this.simpleButtonLog_Click);
      // 
      // ServerMainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(584, 506);
      this.Controls.Add(this.gridControl);
      this.Controls.Add(this.groupControlQueries);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(500, 300);
      this.Name = "ServerMainForm";
      this.Text = "Вспомогательный сервис - сервер - консоль";
      ((System.ComponentModel.ISupportInitialize)(this.gridViewAdresses)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.salePointBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewContacts)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewTrustPersons)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewSalePoints)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.groupControlQueries)).EndInit();
      this.groupControlQueries.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.BindingSource salePointBindingSource;
    private DevExpress.XtraGrid.GridControl gridControl;
    private DevExpress.XtraGrid.Views.Grid.GridView gridViewAdresses;
    private DevExpress.XtraGrid.Views.Grid.GridView gridViewContacts;
    private DevExpress.XtraGrid.Views.Grid.GridView gridViewTrustPersons;
    private DevExpress.XtraGrid.Views.Grid.GridView gridViewSalePoints;
    private DevExpress.XtraGrid.Columns.GridColumn colCode;
    private DevExpress.XtraGrid.Columns.GridColumn colName;
    private DevExpress.XtraGrid.Columns.GridColumn colRegion;
    private DevExpress.XtraGrid.Columns.GridColumn colIP;
    private DevExpress.XtraGrid.Columns.GridColumn colAUX;
    private DevExpress.XtraEditors.GroupControl groupControlQueries;
    private DevExpress.XtraEditors.SimpleButton simpleButtonVersions;
    private DevExpress.XtraEditors.SimpleButton simpleButtonServices;
    private DevExpress.XtraEditors.SimpleButton simpleButtonHardware;
    private DevExpress.XtraEditors.SimpleButton simpleButtonPrinter;
    private DevExpress.XtraEditors.SimpleButton simpleButtonVelcom;
    private DevExpress.XtraEditors.SimpleButton simpleButtonLog;
  }
}