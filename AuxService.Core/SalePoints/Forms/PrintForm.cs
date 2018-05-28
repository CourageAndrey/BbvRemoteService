using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AuxService.Core.SalePoints.Queries;
using DevExpress.XtraEditors;

namespace AuxService.Core.SalePoints.Forms
{
  /// <summary>
  /// Форма ответа на запрос: очередь печати.
  /// </summary>
  public partial class PrintForm : XtraForm
  {
    private PrintForm()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Вывод на экран.
    /// </summary>
    /// <param name="parent">родительская форма</param>
    /// <param name="sp">ПР</param>
    /// <param name="data">информация</param>
    public static void Show(IWin32Window parent, SalePoint sp, List<PrintInfo> data)
    {
      var dialog = new PrintForm();
      dialog.Text = string.Format("Напечатанные документы {0} {1}", sp.Code, sp.Name);
      dialog.printInfoBindingSource.DataSource = data;
      dialog.printInfoBindingSource.ResetBindings(false);
      dialog.memoEditStatistics.Text = getSummary(data).ToString();
      dialog.ShowDialog(parent);
    }

    private void simpleButtonPrint_Click(object sender, EventArgs e)
    {
      gridControl.ShowPrintPreview();
    }

    // подведение итогов
    private static StringBuilder getSummary(List<PrintInfo> jobs)
    {
      int printSummary = 0;
      int maxDoc = 0;
      DateTime dateStart = DateTime.MaxValue;
      DateTime dateEnd = DateTime.MinValue;

      foreach (var job in jobs)
      {
        printSummary += job.NumberOfPages;
        if (dateStart > job.TimeStamp)
          dateStart = job.TimeStamp;
        if (dateEnd < job.TimeStamp)
          dateEnd = job.TimeStamp;
        if (job.NumberOfPages > maxDoc)
          maxDoc = job.NumberOfPages;
      }

      int days = (int)Math.Ceiling((dateEnd - dateStart).TotalDays);
      double inDay = (days > 0) ? (printSummary / days) : printSummary;
      double inMonth = inDay * 30;
      var summary = new StringBuilder();

      summary.AppendLine(string.Format("За месяц в среднем отпечатано {0:N0} страниц.",
        inMonth));
      summary.AppendLine(string.Format("Всего {0} страниц за период с {1} по {2} ({3} дней).",
        printSummary,
        dateStart.ToShortDateString(),
        dateEnd.ToShortDateString(),
        days));
      summary.AppendLine(string.Format("В день в среднем {0:N1} страниц, средний размер документа - {1:N1} страниц, максимальный - {2}.",
        inDay,
        (double)printSummary / jobs.Count,
        maxDoc));

      return summary;
    }
  }
}