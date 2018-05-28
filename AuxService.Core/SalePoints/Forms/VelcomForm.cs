using System.Collections.Generic;
using System.Windows.Forms;
using AuxService.Core.SalePoints.Queries;
using DevExpress.XtraEditors;

namespace AuxService.Core.SalePoints.Forms
{
  /// <summary>
  /// Форма ответа на запрос: трафик.
  /// </summary>
  public partial class VelcomForm : XtraForm
  {
    private VelcomForm()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Вывод на экран.
    /// </summary>
    /// <param name="parent">родительская форма</param>
    /// <param name="sp">ПР</param>
    /// <param name="data">информация</param>
    public static void Show(IWin32Window parent, SalePoint sp, List<VelcomInfo> data)
    {
      var dialog = new VelcomForm();
      dialog.Text = string.Format("Детализация трафика {0} {1}", sp.Code, sp.Name);
      dialog.velcomInfoBindingSource.DataSource = data;
      dialog.velcomInfoBindingSource.ResetBindings(false);
      dialog.ShowDialog(parent);
    }
  }
}