using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sef.DX;

namespace AuxService.Core.Service
{
  /// <summary>
  /// Диалог выбора службы.
  /// </summary>
  public partial class SelectServiceDialog : XtraForm
  {
    private SelectServiceDialog()
    {
      InitializeComponent();

      serviceRecordBindingSource.DataSource = ServiceRecord.GetList();
      serviceRecordBindingSource.ResetBindings(false);
    }

    private void simpleButtonOK_Click(object sender, EventArgs e)
    {
      var selected = DevExpressHelper.GetSelectedRecord<ServiceRecord>(gridViewServices);
      if (selected == null)
        DialogResult = DialogResult.None;
    }

    /// <summary>
    /// Вызов диалога.
    /// </summary>
    /// <param name="parent">окно-родитель</param>
    /// <returns>выбранный сервис либо null</returns>
    public static ServiceRecord Execute(IWin32Window parent)
    {
      using (var dialog = new SelectServiceDialog())
      {
        var result = dialog.ShowDialog(parent);
        return (result == DialogResult.OK)
          ? DevExpressHelper.GetSelectedRecord<ServiceRecord>(dialog.gridViewServices)
          : null;
      }
    }

    private void gridViewServices_DoubleClick(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
    }
  }
}