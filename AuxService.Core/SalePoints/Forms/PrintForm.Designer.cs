namespace AuxService.Core.SalePoints.Forms
{
  partial class PrintForm
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
      this.printInfoBindingSource = new System.Windows.Forms.BindingSource();
      this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colNumberOfPages = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colTimeStamp = new DevExpress.XtraGrid.Columns.GridColumn();
      this.memoEditStatistics = new DevExpress.XtraEditors.MemoEdit();
      this.simpleButtonPrint = new DevExpress.XtraEditors.SimpleButton();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.printInfoBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.memoEditStatistics.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      this.SuspendLayout();
      // 
      // gridControl
      // 
      this.gridControl.DataSource = this.printInfoBindingSource;
      this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridControl.Location = new System.Drawing.Point(0, 100);
      this.gridControl.MainView = this.gridView;
      this.gridControl.Name = "gridControl";
      this.gridControl.Size = new System.Drawing.Size(547, 260);
      this.gridControl.TabIndex = 1;
      this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
      // 
      // printInfoBindingSource
      // 
      this.printInfoBindingSource.DataSource = typeof(AuxService.Core.SalePoints.Queries.PrintInfo);
      // 
      // gridView
      // 
      this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colNumberOfPages,
            this.colTimeStamp});
      this.gridView.GridControl = this.gridControl;
      this.gridView.Name = "gridView";
      this.gridView.OptionsBehavior.Editable = false;
      this.gridView.OptionsBehavior.ReadOnly = true;
      this.gridView.OptionsView.ColumnAutoWidth = false;
      // 
      // colName
      // 
      this.colName.Caption = "Документ";
      this.colName.FieldName = "Name";
      this.colName.Name = "colName";
      this.colName.Visible = true;
      this.colName.VisibleIndex = 2;
      this.colName.Width = 350;
      // 
      // colNumberOfPages
      // 
      this.colNumberOfPages.Caption = "Страниц";
      this.colNumberOfPages.FieldName = "NumberOfPages";
      this.colNumberOfPages.Name = "colNumberOfPages";
      this.colNumberOfPages.Visible = true;
      this.colNumberOfPages.VisibleIndex = 1;
      // 
      // colTimeStamp
      // 
      this.colTimeStamp.Caption = "Время";
      this.colTimeStamp.DisplayFormat.FormatString = "dd.MM.yyyy hh:mm:ss";
      this.colTimeStamp.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
      this.colTimeStamp.FieldName = "TimeStamp";
      this.colTimeStamp.Name = "colTimeStamp";
      this.colTimeStamp.Visible = true;
      this.colTimeStamp.VisibleIndex = 0;
      this.colTimeStamp.Width = 115;
      // 
      // memoEditStatistics
      // 
      this.memoEditStatistics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.memoEditStatistics.Location = new System.Drawing.Point(86, 5);
      this.memoEditStatistics.Name = "memoEditStatistics";
      this.memoEditStatistics.Properties.ReadOnly = true;
      this.memoEditStatistics.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
      this.memoEditStatistics.Size = new System.Drawing.Size(449, 90);
      this.memoEditStatistics.TabIndex = 1;
      // 
      // simpleButtonPrint
      // 
      this.simpleButtonPrint.Location = new System.Drawing.Point(5, 5);
      this.simpleButtonPrint.Name = "simpleButtonPrint";
      this.simpleButtonPrint.Size = new System.Drawing.Size(75, 23);
      this.simpleButtonPrint.TabIndex = 0;
      this.simpleButtonPrint.Text = "Печать";
      this.simpleButtonPrint.Click += new System.EventHandler(this.simpleButtonPrint_Click);
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.simpleButtonPrint);
      this.panelControl1.Controls.Add(this.memoEditStatistics);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(547, 100);
      this.panelControl1.TabIndex = 0;
      // 
      // PrintForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(547, 360);
      this.Controls.Add(this.gridControl);
      this.Controls.Add(this.panelControl1);
      this.Name = "PrintForm";
      this.ShowIcon = false;
      ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.printInfoBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.memoEditStatistics.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridControl;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView;
    private DevExpress.XtraEditors.MemoEdit memoEditStatistics;
    private DevExpress.XtraEditors.SimpleButton simpleButtonPrint;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private System.Windows.Forms.BindingSource printInfoBindingSource;
    private DevExpress.XtraGrid.Columns.GridColumn colName;
    private DevExpress.XtraGrid.Columns.GridColumn colNumberOfPages;
    private DevExpress.XtraGrid.Columns.GridColumn colTimeStamp;
  }
}