using System.Collections.Generic;
using System.Windows.Forms;
using AuxService.Core.SalePoints.Queries;
using DevExpress.XtraEditors;

namespace AuxService.Core.SalePoints.Forms
{
  /// <summary>
  /// Форма ответа на запрос: состояние служб.
  /// </summary>
  public partial class StatusForm : XtraForm
  {
    private StatusForm()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Вывод на экран.
    /// </summary>
    /// <param name="parent">родительская форма</param>
    /// <param name="sp">ПР</param>
    /// <param name="data">информация</param>
    public static void Show(IWin32Window parent, SalePoint sp, List<StatusInfo> data)
    {
      var dialog = new StatusForm();
      dialog.Text = string.Format("Состояние {0} {1}", sp.Code, sp.Name);
      dialog.statusInfoBindingSource.DataSource = data;
      dialog.statusInfoBindingSource.ResetBindings(false);
      dialog.ShowDialog(parent);
    }
  }
}