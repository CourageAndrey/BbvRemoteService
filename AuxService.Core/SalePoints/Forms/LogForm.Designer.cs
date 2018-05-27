namespace AuxService.Core.SalePoints.Forms
{
  partial class LogForm
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
      this.comboBoxEditLogSelect = new DevExpress.XtraEditors.ComboBoxEdit();
      this.memoEditTextLog = new DevExpress.XtraEditors.MemoEdit();
      this.logControl = new Sef.DX.LogControl();
      ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLogSelect.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.memoEditTextLog.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // comboBoxEditLogSelect
      // 
      this.comboBoxEditLogSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.comboBoxEditLogSelect.Location = new System.Drawing.Point(12, 12);
      this.comboBoxEditLogSelect.Name = "comboBoxEditLogSelect";
      this.comboBoxEditLogSelect.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.comboBoxEditLogSelect.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
      this.comboBoxEditLogSelect.Size = new System.Drawing.Size(768, 20);
      this.comboBoxEditLogSelect.TabIndex = 0;
      this.comboBoxEditLogSelect.SelectedIndexChanged += new System.EventHandler(this.comboBoxEditLogSelect_SelectedIndexChanged);
      // 
      // memoEditTextLog
      // 
      this.memoEditTextLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.memoEditTextLog.Location = new System.Drawing.Point(12, 38);
      this.memoEditTextLog.Name = "memoEditTextLog";
      this.memoEditTextLog.Properties.ReadOnly = true;
      this.memoEditTextLog.Properties.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.memoEditTextLog.Properties.WordWrap = false;
      this.memoEditTextLog.Size = new System.Drawing.Size(768, 313);
      this.memoEditTextLog.TabIndex = 1;
      this.memoEditTextLog.Visible = false;
      // 
      // logControl
      // 
      this.logControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.logControl.Location = new System.Drawing.Point(12, 40);
      this.logControl.MinimumSize = new System.Drawing.Size(400, 200);
      this.logControl.Name = "logControl";
      this.logControl.Size = new System.Drawing.Size(768, 311);
      this.logControl.TabIndex = 2;
      this.logControl.Visible = false;
      // 
      // LogForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(792, 363);
      this.Controls.Add(this.comboBoxEditLogSelect);
      this.Controls.Add(this.logControl);
      this.Controls.Add(this.memoEditTextLog);
      this.Name = "LogForm";
      this.ShowIcon = false;
      ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditLogSelect.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.memoEditTextLog.Properties)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditLogSelect;
    private DevExpress.XtraEditors.MemoEdit memoEditTextLog;
    private Sef.DX.LogControl logControl;
  }
}