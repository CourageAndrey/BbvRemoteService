using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using AuxService.Core.Settings;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using Sef.DX;
using Sef.Utility.Applications;

namespace AuxService.BackupChecker
{
  /// <summary>
  /// Программа клиента.
  /// </summary>
  internal sealed class CheckerProgram : ProgramExt<CheckerProgram, ErrorForm>
  {
    /// <summary>
    /// ctor.
    /// </summary>
    public CheckerProgram()
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
      Config.LoadOrCreate();
      var files = new List<FileInfo>(new DirectoryInfo(Config.Instance.OutputPath).GetFiles());
      files.RemoveAll(f => f.Extension.ToLower() != ".zip");
      files.Sort((f1, f2) => f2.CreationTime.CompareTo(f1.CreationTime));
      var fileDate = (files.Count > 0) ? files[0].CreationTime : DateTime.MinValue;
      var now = DateTime.Now;
      var lastDate = (now.DayOfWeek == DayOfWeek.Monday) ? now.AddDays(-3) : now.AddDays(-1);
      if (fileDate.Date < lastDate.Date)
        XtraMessageBox.Show(
          "Возникла ошибка при создании резервных копий баз данных! Обратитесь к системному администратору.", 
          "Предупреждение Aux Service", 
          MessageBoxButtons.OK,
          MessageBoxIcon.Error);
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
