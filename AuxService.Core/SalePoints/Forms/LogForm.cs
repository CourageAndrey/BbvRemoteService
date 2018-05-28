using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AuxService.Core.SalePoints.Queries;
using DevExpress.XtraEditors;
using Sef.Utility.Common;

namespace AuxService.Core.SalePoints.Forms
{
  /// <summary>
  /// Форма ответа на запрос: журнал работы.
  /// </summary>
  public partial class LogForm : XtraForm
  {
    private LogForm()
    {
      InitializeComponent();
    }

    private List<LogInfo> logs;

    /// <summary>
    /// Вывод на экран.
    /// </summary>
    /// <param name="parent">родительская форма</param>
    /// <param name="sp">ПР</param>
    /// <param name="data">информация</param>
    public static void Show(IWin32Window parent, SalePoint sp, List<LogInfo> data)
    {
      var dialog = new LogForm();
      dialog.Text = string.Format("Журналы работы {0} {1}", sp.Code, sp.Name);
      dialog.logs = data;
      dialog.comboBoxEditLogSelect.Properties.Items.Clear();
      foreach (var log in dialog.logs)
        dialog.comboBoxEditLogSelect.Properties.Items.Add(log.Program);
      dialog.comboBoxEditLogSelect.SelectedIndex = dialog.logs.Count - 1;
      dialog.ShowDialog(parent);
    }

    private void comboBoxEditLogSelect_SelectedIndexChanged(object sender, EventArgs e)
    {
      var log = logs[comboBoxEditLogSelect.SelectedIndex];
      memoEditTextLog.Visible = logControl.Visible = false;
      using (new AutoWaitCursor())
      {
        bool loaded = false;

        // попытка загрузить лог как сообщения AUX
        try
        {
          logControl.LoadFromString(log.Log);
          logControl.Visible = loaded = true;
        }
        catch
        { }

        // попытка загрузить лог как журнал МОДИСа
        if (!loaded)
          try
          {
            var lines = log.Log.Split(ModisLogParser.LineSeparator);
            if (lines.Length > 50)
              if (XtraMessageBox.Show(
                this,
                string.Format("Операция займёт достаточно длительное время (около {0} секунд). Желаете продолжить?", lines.Length/20),
                "Продолжить?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) != DialogResult.Yes)
                throw new Exception();

            var ready = new List<string>();
            foreach (var _line in lines)
            {
              string line = _line.Trim();
              if (!string.IsNullOrEmpty(line))
                ready.Add(line);
            }

            logControl.LoadFromString(ModisLogParser.Convert(ready));
            logControl.Visible = loaded = true;
          }
          catch
          { }

        // если не получилось - выводим простой текст
        if (!loaded)
        {
          memoEditTextLog.Text = log.Log;
          memoEditTextLog.Visible = true;
        }
      }
    }
  }
}