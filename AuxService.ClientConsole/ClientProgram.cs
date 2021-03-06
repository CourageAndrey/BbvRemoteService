﻿using System;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using Sef.DX;
using Sef.Utility.Applications;

namespace AuxService.ClientConsole
{
  /// <summary>
  /// Программа клиента.
  /// </summary>
  internal sealed class ClientProgram : ProgramExt<ClientProgram, ErrorForm>
  {
    /// <summary>
    /// ctor.
    /// </summary>
    public ClientProgram()
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
      Application.Run(new ClientMainForm());
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
