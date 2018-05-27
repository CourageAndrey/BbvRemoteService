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
    /// <param name="info">информация</param>
    public static void Show(IWin32Window parent, SalePoint sp, StatusInfoList info)
    {
      var dialog = new StatusForm();
      dialog.Text = string.Format("Состояние {0} {1}", sp.Code, sp.Name);
      dialog.statusInfoBindingSource.DataSource = info.Statuses;
      dialog.statusInfoBindingSource.ResetBindings(false);
      dialog.ShowDialog(parent);
    }
  }
}