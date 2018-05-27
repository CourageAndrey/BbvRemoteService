using System.Windows.Forms;
using AuxService.Core.SalePoints.Queries;
using DevExpress.XtraEditors;

namespace AuxService.Core.SalePoints.Forms
{
  /// <summary>
  /// Форма ответа на запрос: системная информация.
  /// </summary>
  public partial class SystemForm : XtraForm
  {
    private SystemForm()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Вывод на экран.
    /// </summary>
    /// <param name="parent">родительская форма</param>
    /// <param name="sp">ПР</param>
    /// <param name="info">информация</param>
    public static void Show(IWin32Window parent, SalePoint sp, SystemInfo info)
    {
      var dialog = new SystemForm();
      dialog.Text = string.Format("Системная информация {0} {1}", sp.Code, sp.Name);
      dialog.systemInfoBindingSource.DataSource = info;
      dialog.systemInfoBindingSource.ResetBindings(false);
      dialog.ShowDialog(parent);
    }
  }
}