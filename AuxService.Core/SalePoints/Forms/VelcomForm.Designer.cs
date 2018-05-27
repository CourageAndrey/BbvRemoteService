namespace AuxService.Core.SalePoints.Forms
{
  partial class VelcomForm
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
      this.velcomInfoBindingSource = new System.Windows.Forms.BindingSource();
      this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colParameter = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colValue = new DevExpress.XtraGrid.Columns.GridColumn();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.velcomInfoBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
      this.SuspendLayout();
      // 
      // gridControl
      // 
      this.gridControl.DataSource = this.velcomInfoBindingSource;
      this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridControl.Location = new System.Drawing.Point(0, 0);
      this.gridControl.MainView = this.gridView;
      this.gridControl.Name = "gridControl";
      this.gridControl.Size = new System.Drawing.Size(391, 296);
      this.gridControl.TabIndex = 0;
      this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
      // 
      // velcomInfoBindingSource
      // 
      this.velcomInfoBindingSource.DataSource = typeof(AuxService.Core.SalePoints.Queries.VelcomInfo);
      // 
      // gridView
      // 
      this.gridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colParameter,
            this.colValue});
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
      this.colParameter.OptionsFilter.AllowFilter = false;
      this.colParameter.Visible = true;
      this.colParameter.VisibleIndex = 0;
      this.colParameter.Width = 238;
      // 
      // colValue
      // 
      this.colValue.Caption = "Значение";
      this.colValue.FieldName = "ValueFormatted";
      this.colValue.Name = "colValue";
      this.colValue.Visible = true;
      this.colValue.VisibleIndex = 1;
      this.colValue.Width = 135;
      // 
      // VelcomForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(391, 296);
      this.Controls.Add(this.gridControl);
      this.Name = "VelcomForm";
      this.ShowIcon = false;
      ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.velcomInfoBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridControl;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView;
    private System.Windows.Forms.BindingSource velcomInfoBindingSource;
    private DevExpress.XtraGrid.Columns.GridColumn colParameter;
    private DevExpress.XtraGrid.Columns.GridColumn colValue;
  }
}