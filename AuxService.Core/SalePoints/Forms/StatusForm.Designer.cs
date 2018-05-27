namespace AuxService.Core.SalePoints.Forms
{
  partial class StatusForm
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
      this.gridControl = new DevExpress.XtraGrid.GridControl();
      this.statusInfoBindingSource = new System.Windows.Forms.BindingSource();
      this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colParameter = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colValid = new DevExpress.XtraGrid.Columns.GridColumn();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusInfoBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
      this.SuspendLayout();
      // 
      // gridControl
      // 
      this.gridControl.DataSource = this.statusInfoBindingSource;
      this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridControl.Location = new System.Drawing.Point(0, 0);
      this.gridControl.MainView = this.gridView;
      this.gridControl.Name = "gridControl";
      this.gridControl.Size = new System.Drawing.Size(386, 262);
      this.gridControl.TabIndex = 0;
      this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
      // 
      // statusInfoBindingSource
      // 
      this.statusInfoBindingSource.DataSource = typeof(AuxService.Core.SalePoints.Queries.StatusInfo);
      // 
      // gridView
      // 
      this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colParameter,
            this.colStatus,
            this.colValid});
      this.gridView.GridControl = this.gridControl;
      this.gridView.Name = "gridView";
      this.gridView.OptionsBehavior.Editable = false;
      this.gridView.OptionsBehavior.ReadOnly = true;
      this.gridView.OptionsView.ShowGroupPanel = false;
      // 
      // colParameter
      // 
      this.colParameter.Caption = "Параметр";
      this.colParameter.FieldName = "Parameter";
      this.colParameter.Name = "colParameter";
      this.colParameter.Visible = true;
      this.colParameter.VisibleIndex = 0;
      this.colParameter.Width = 182;
      // 
      // colStatus
      // 
      this.colStatus.Caption = "Состояние";
      this.colStatus.FieldName = "Status";
      this.colStatus.Name = "colStatus";
      this.colStatus.Visible = true;
      this.colStatus.VisibleIndex = 1;
      this.colStatus.Width = 103;
      // 
      // colValid
      // 
      this.colValid.Caption = "В порядке";
      this.colValid.FieldName = "Valid";
      this.colValid.Name = "colValid";
      this.colValid.Visible = true;
      this.colValid.VisibleIndex = 2;
      this.colValid.Width = 83;
      // 
      // StatusForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(386, 262);
      this.Controls.Add(this.gridControl);
      this.Name = "StatusForm";
      this.ShowIcon = false;
      ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.statusInfoBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridControl;
    private System.Windows.Forms.BindingSource statusInfoBindingSource;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView;
    private DevExpress.XtraGrid.Columns.GridColumn colParameter;
    private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    private DevExpress.XtraGrid.Columns.GridColumn colValid;
  }
}