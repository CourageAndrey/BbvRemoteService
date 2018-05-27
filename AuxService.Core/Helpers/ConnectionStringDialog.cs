using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sef.Utility.Database;

namespace AuxService.Core.Helpers
{
  /// <summary>
  /// Диалог настройки подключения к БД.
  /// </summary>
  public partial class ConnectionStringDialog : XtraForm
  {
    private ConnectionStringDialog()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Вызов.
    /// </summary>
    /// <param name="parent">родительское окно</param>
    /// <param name="connection">строка подключения</param>
    /// <returns>новая (изменённая) либо прежняя строка подключения</returns>
    public static ConnectionWrapper Execute(IWin32Window parent, ConnectionWrapper connection)
    {
      using (var dialog = new ConnectionStringDialog())
      {
        var copy = connection.CloneTyped();
        dialog.connectionStringControl.Value = copy;
        var result = dialog.ShowDialog();
        return (result == DialogResult.OK)
          ? copy
          : connection;
      }
    }
  }
}