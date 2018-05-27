using System.Windows.Forms;
using AuxService.Core.SalePoints.Queries;
using DevExpress.XtraEditors;

namespace AuxService.Core.SalePoints.Forms
{
  /// <summary>
  /// Форма ответа на запрос: версии ПО.
  /// </summary>
  public partial class VersionForm : XtraForm
  {
    private VersionForm()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Вывод на экран.
    /// </summary>
    /// <param name="parent">родительская форма</param>
    /// <param name="sp">ПР</param>
    /// <param name="info">информация</param>
    public static void Show(IWin32Window parent, SalePoint sp, VersionInfoList info)
    {
      var dialog = new VersionForm();
      dialog.Text = string.Format("Версии ПО {0} {1}", sp.Code, sp.Name);
      dialog.versionInfoBindingSource.DataSource = info.Versions;
      dialog.versionInfoBindingSource.ResetBindings(false);
      dialog.ShowDialog(parent);
    }
  }
}