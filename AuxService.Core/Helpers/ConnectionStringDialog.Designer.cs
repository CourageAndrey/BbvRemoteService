namespace AuxService.Core.Helpers
{
  partial class ConnectionStringDialog
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
      this.connectionStringControl = new Sef.DX.ConnectionStringControl();
      this.simpleButtonOK = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonCancel = new DevExpress.XtraEditors.SimpleButton();
      this.SuspendLayout();
      // 
      // connectionStringControl
      // 
      this.connectionStringControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.connectionStringControl.Location = new System.Drawing.Point(0, 0);
      this.connectionStringControl.MaximumSize = new System.Drawing.Size(800, 600);
      this.connectionStringControl.MinimumSize = new System.Drawing.Size(350, 200);
      this.connectionStringControl.Name = "connectionStringControl";
      this.connectionStringControl.Size = new System.Drawing.Size(419, 209);
      this.connectionStringControl.TabIndex = 0;
      // 
      // simpleButtonOK
      // 
      this.simpleButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.simpleButtonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.simpleButtonOK.Location = new System.Drawing.Point(251, 215);
      this.simpleButtonOK.Name = "simpleButtonOK";
      this.simpleButtonOK.Size = new System.Drawing.Size(75, 23);
      this.simpleButtonOK.TabIndex = 1;
      this.simpleButtonOK.Text = "ОК";
      // 
      // simpleButtonCancel
      // 
      this.simpleButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.simpleButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.simpleButtonCancel.Location = new System.Drawing.Point(332, 215);
      this.simpleButtonCancel.Name = "simpleButtonCancel";
      this.simpleButtonCancel.Size = new System.Drawing.Size(75, 23);
      this.simpleButtonCancel.TabIndex = 2;
      this.simpleButtonCancel.Text = "Отмена";
      // 
      // ConnectionStringDialog
      // 
      this.AcceptButton = this.simpleButtonOK;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.simpleButtonCancel;
      this.ClientSize = new System.Drawing.Size(419, 250);
      this.Controls.Add(this.simpleButtonCancel);
      this.Controls.Add(this.simpleButtonOK);
      this.Controls.Add(this.connectionStringControl);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "ConnectionStringDialog";
      this.ShowInTaskbar = false;
      this.Text = "Выберите БД...";
      this.ResumeLayout(false);

    }

    #endregion

    private Sef.DX.ConnectionStringControl connectionStringControl;
    private DevExpress.XtraEditors.SimpleButton simpleButtonOK;
    private DevExpress.XtraEditors.SimpleButton simpleButtonCancel;

  }
}