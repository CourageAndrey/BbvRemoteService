namespace AuxService.Core.SalePoints.Forms
{
  partial class VersionForm
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
      this.versionInfoBindingSource = new System.Windows.Forms.BindingSource();
      this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colProgram = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colVersionNumber = new DevExpress.XtraGrid.Columns.GridColumn();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.versionInfoBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
      this.SuspendLayout();
      // 
      // gridControl
      // 
      this.gridControl.DataSource = this.versionInfoBindingSource;
      this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridControl.Location = new System.Drawing.Point(0, 0);
      this.gridControl.MainView = this.gridView;
      this.gridControl.Name = "gridControl";
      this.gridControl.Size = new System.Drawing.Size(392, 264);
      this.gridControl.TabIndex = 0;
      this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
      // 
      // versionInfoBindingSource
      // 
      this.versionInfoBindingSource.DataSource = typeof(AuxService.Core.SalePoints.Queries.VersionInfo);
      // 
      // gridView
      // 
      this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProgram,
            this.colVersionNumber});
      this.gridView.GridControl = this.gridControl;
      this.gridView.Name = "gridView";
      this.gridView.OptionsBehavior.Editable = false;
      this.gridView.OptionsBehavior.ReadOnly = true;
      this.gridView.OptionsView.ShowGroupPanel = false;
      // 
      // colProgram
      // 
      this.colProgram.Caption = "Программа";
      this.colProgram.FieldName = "Program";
      this.colProgram.Name = "colProgram";
      this.colProgram.Visible = true;
      this.colProgram.VisibleIndex = 0;
      this.colProgram.Width = 223;
      // 
      // colVersionNumber
      // 
      this.colVersionNumber.Caption = "Версия";
      this.colVersionNumber.FieldName = "VersionNumber";
      this.colVersionNumber.Name = "colVersionNumber";
      this.colVersionNumber.Visible = true;
      this.colVersionNumber.VisibleIndex = 1;
      this.colVersionNumber.Width = 151;
      // 
      // VersionForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(392, 264);
      this.Controls.Add(this.gridControl);
      this.Name = "VersionForm";
      this.ShowIcon = false;
      ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.versionInfoBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridControl;
    private System.Windows.Forms.BindingSource versionInfoBindingSource;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView;
    private DevExpress.XtraGrid.Columns.GridColumn colProgram;
    private DevExpress.XtraGrid.Columns.GridColumn colVersionNumber;
  }
}