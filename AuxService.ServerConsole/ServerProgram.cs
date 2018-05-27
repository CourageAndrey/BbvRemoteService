using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using Sef.DX;
using Sef.Utility.Applications;

namespace AuxService.ServerConsole
{
  /// <summary>
  /// Программа сервера.
  /// </summary>
  internal sealed class ServerProgram : ProgramExt<ServerProgram, ErrorForm>
  {
    /// <summary>
    /// ctor.
    /// </summary>
    public ServerProgram()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      SkinManager.EnableFormSkins();
      BonusSkins.Register();
      UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
    }

    /// <summary>
    /// Переопределённый обработчик неопределённых исключений.
    /// </summary>
    /// <param name="sender">отправитель</param>
    /// <param name="e">параметры</param>
    /// <remarks>Используется потому, что обработать все исключения,
    /// особенно GUI, в родительской библиотеке невозможно.</remarks>
    protected override void UnhandledExceptionHandlerStub(object sender, UnhandledExceptionEventArgs e)
    {
      UnhandledExceptionHandler(sender, e);
    }

    /// <summary>
    /// Шаблон запуска.
    /// </summary>
    protected override void Run()
    {
      Application.Run(new ServerMainForm());
    }

    /// <summary>
    /// Собственно, запуск программы.
    /// </summary>
    [STAThread]
    static void Main()
    {
      MainBase();
    }
  }
}
