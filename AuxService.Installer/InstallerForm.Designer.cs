namespace AuxService.Installer
{
  partial class InstallerForm
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
      this.simpleButtonPrepare = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButtonInstall = new DevExpress.XtraEditors.SimpleButton();
      this.listBoxControlLog = new DevExpress.XtraEditors.ListBoxControl();
      ((System.ComponentModel.ISupportInitialize)(this.listBoxControlLog)).BeginInit();
      this.SuspendLayout();
      // 
      // simpleButtonPrepare
      // 
      this.simpleButtonPrepare.Location = new System.Drawing.Point(12, 12);
      this.simpleButtonPrepare.Name = "simpleButtonPrepare";
      this.simpleButtonPrepare.Size = new System.Drawing.Size(75, 23);
      this.simpleButtonPrepare.TabIndex = 0;
      this.simpleButtonPrepare.Text = "Проверить";
      this.simpleButtonPrepare.Click += new System.EventHandler(this.simpleButtonPrepare_Click);
      // 
      // simpleButtonInstall
      // 
      this.simpleButtonInstall.Enabled = false;
      this.simpleButtonInstall.Location = new System.Drawing.Point(93, 12);
      this.simpleButtonInstall.Name = "simpleButtonInstall";
      this.simpleButtonInstall.Size = new System.Drawing.Size(75, 23);
      this.simpleButtonInstall.TabIndex = 1;
      this.simpleButtonInstall.Text = "Установить";
      this.simpleButtonInstall.Click += new System.EventHandler(this.simpleButtonInstall_Click);
      // 
      // listBoxControlLog
      // 
      this.listBoxControlLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.listBoxControlLog.Location = new System.Drawing.Point(12, 41);
      this.listBoxControlLog.Name = "listBoxControlLog";
      this.listBoxControlLog.Size = new System.Drawing.Size(794, 339);
      this.listBoxControlLog.TabIndex = 2;
      // 
      // InstallerForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(818, 392);
      this.Controls.Add(this.listBoxControlLog);
      this.Controls.Add(this.simpleButtonInstall);
      this.Controls.Add(this.simpleButtonPrepare);
      this.Name = "InstallerForm";
      this.ShowIcon = false;
      this.Text = "Aux Service 3 - установка";
      ((System.ComponentModel.ISupportInitialize)(this.listBoxControlLog)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.SimpleButton simpleButtonPrepare;
    private DevExpress.XtraEditors.SimpleButton simpleButtonInstall;
    private DevExpress.XtraEditors.ListBoxControl listBoxControlLog;


  }
}
