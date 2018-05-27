namespace AuxService.Core.Service
{
  partial class SelectServiceDialog
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
      this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
      this.gridControlServices = new DevExpress.XtraGrid.GridControl();
      this.serviceRecordBindingSource = new System.Windows.Forms.BindingSource();
      this.gridViewServices = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colServiceName = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colDisplayName = new DevExpress.XtraGrid.Columns.GridColumn();
      ((System.ComponentModel.ISupportInitialize)(this.gridControlServices)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.serviceRecordBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewServices)).BeginInit();
      this.SuspendLayout();
      // 
      // simpleButtonCancel
      // 
      this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.simpleButtonCancel.Location = new System.Drawing.Point(292, 359);
      this.simpleButtonCancel.Name = "simpleButtonCancel";
      this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
      this.simpleButtonCancel.TabIndex = 0;
      this.simpleButtonCancel.Text = "Отмена";
      // 
      // simpleButtonOK
      // 
      this.simpleButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.simpleButtonOK.Location = new System.Drawing.Point(211, 359);
      this.simpleButtonOK.Name = "simpleButtonOK";
      this.simpleButtonOK.Size = new System.Drawing.Size(75, 23);
      this.simpleButtonOK.TabIndex = 1;
      this.simpleButtonOK.Text = "ОК";
      this.simpleButtonOK.Click += new System.EventHandler(this.simpleButtonOK_Click);
      // 
      // gridControlServices
      // 
      this.gridControlServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gridControlServices.DataSource = this.serviceRecordBindingSource;
      this.gridControlServices.Location = new System.Drawing.Point(-1, 0);
      this.gridControlServices.MainView = this.gridViewServices;
      this.gridControlServices.Name = "gridControlServices";
      this.gridControlServices.Size = new System.Drawing.Size(381, 353);
      this.gridControlServices.TabIndex = 2;
      this.gridControlServices.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewServices});
      // 
      // serviceRecordBindingSource
      // 
      this.serviceRecordBindingSource.DataSource = typeof(AuxService.Core.Service.ServiceRecord);
      // 
      // gridViewServices
      // 
      this.gridViewServices.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colServiceName,
            this.colDisplayName});
      this.gridViewServices.GridControl = this.gridControlServices;
      this.gridViewServices.Name = "gridViewServices";
      this.gridViewServices.OptionsBehavior.Editable = false;
      this.gridViewServices.OptionsBehavior.ReadOnly = true;
      this.gridViewServices.OptionsView.ColumnAutoWidth = false;
      this.gridViewServices.OptionsView.ShowGroupPanel = false;
      this.gridViewServices.DoubleClick += new System.EventHandler(this.gridViewServices_DoubleClick);
      // 
      // colServiceName
      // 
      this.colServiceName.Caption = "Название";
      this.colServiceName.FieldName = "ServiceName";
      this.colServiceName.Name = "colServiceName";
      this.colServiceName.OptionsColumn.ReadOnly = true;
      this.colServiceName.Visible = true;
      this.colServiceName.VisibleIndex = 0;
      this.colServiceName.Width = 127;
      // 
      // colDisplayName
      // 
      this.colDisplayName.Caption = "Описание";
      this.colDisplayName.FieldName = "DisplayName";
      this.colDisplayName.Name = "colDisplayName";
      this.colDisplayName.OptionsColumn.ReadOnly = true;
      this.colDisplayName.Visible = true;
      this.colDisplayName.VisibleIndex = 1;
      this.colDisplayName.Width = 242;
      // 
      // SelectServiceDialog
      // 
      this.AcceptButton = this.simpleButtonOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.simpleButtonCancel;
      this.ClientSize = new System.Drawing.Size(379, 394);
      this.Controls.Add(this.gridControlServices);
      this.Controls.Add(this.simpleButtonOK);
      this.Controls.Add(this.simpleButtonCancel);
      this.MinimumSize = new System.Drawing.Size(350, 300);
      this.Name = "SelectServiceDialog";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Выбор службы";
      ((System.ComponentModel.ISupportInitialize)(this.gridControlServices)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.serviceRecordBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridViewServices)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;
    private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
    private DevExpress.XtraGrid.GridControl gridControlServices;
    private DevExpress.XtraGrid.Views.Grid.GridView gridViewServices;
    private System.Windows.Forms.BindingSource serviceRecordBindingSource;
    private DevExpress.XtraGrid.Columns.GridColumn colServiceName;
    private DevExpress.XtraGrid.Columns.GridColumn colDisplayName;
  }
}