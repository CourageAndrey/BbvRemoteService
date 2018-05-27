using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ServiceProcess;
using System.Windows.Forms;
using Sef.DX;
using Sef.Utility.Applications;

namespace AuxService.Core.Service
{
  /// <summary>
  /// Экземпляр службы.
  /// </summary>
  public class ServiceRecord
  {
    #region Свойства

    // ServiceController службы
    // если null - ещё не была осуществлена привязка
    private ServiceController controller;

    // имя службы, которое используется до и для привязки
    private readonly string serviceName;

    /// <summary>
    /// Имя службы.
    /// </summary>
    public string ServiceName
    { get { return IsInstalled ? controller.ServiceName : serviceName; } }

    /// <summary>
    /// Отображемое имя службы.
    /// </summary>
    public string DisplayName
    { get { return IsInstalled ? controller.DisplayName : null; } }

    /// <summary>
    /// Состояние службы.
    /// </summary>
    public ServiceControllerStatus? Status
    { get { return IsInstalled ? controller.Status : (ServiceControllerStatus?) null; } }

    /// <summary>
    /// Строка состояния службы.
    /// </summary>
    public string StatusString
    { get { return IsInstalled ? serviceStatusNames[controller.Status] : "Не установлена!"; } }

    /// <summary>
    /// Флаг: службы установлена на компьютере.
    /// </summary>
    public bool IsInstalled
    { get { return controller != null; } }

    /// <summary>
    /// Флаг: службы остановлена.
    /// </summary>
    public bool IsStopped
    { get { return IsInstalled && (controller.Status != ServiceControllerStatus.Running); } }

    #endregion

    #region Управление
    
    /// <summary>
    /// Запуск.
    /// </summary>
    /// <param name="parent">окно, от имени которого действуем</param>
    public void Start(IWin32Window parent)
    {
      serviceControlWrapper(parent, startService);
    }

    /// <summary>
    /// Остановка.
    /// </summary>
    /// <param name="parent">окно, от имени которого действуем</param>
    public void Stop(IWin32Window parent)
    {
      serviceControlWrapper(parent, stopService);
    }

    /// <summary>
    /// Перезапуск.
    /// </summary>
    /// <param name="parent">окно, от имени которого действуем</param>
    public void Restart(IWin32Window parent)
    {
      serviceControlWrapper(parent, () => { stopService(); startService(); });
    }

    // обёртка методов управления службой
    private void serviceControlWrapper(IWin32Window parent, Action manageMethod)
    {
      try
      {
        if (controller != null)
          manageMethod();
      }
      catch (Exception ex)
      {
        if ((ex is Win32Exception) || (ex is InvalidOperationException) || (ex is System.ServiceProcess.TimeoutException))
          ErrorHelper.ShowError<ErrorForm>(parent, ex);
        else
          throw;
      }
    }

    // время ожидания изменения состояния службы (15 сек - самое то)
    private const int timeoutServiceWaiting = 15;

    // запуск службы с ожиданием
    private void startService()
    {
      controller.Start();
      controller.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(timeoutServiceWaiting));
    }

    // остановка службы с ожиданием
    private void stopService()
    {
      controller.Stop();
      controller.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(timeoutServiceWaiting));
    }

    #endregion
    
    // имена состояний службы для отображения
    private static readonly Dictionary<ServiceControllerStatus, string> serviceStatusNames = new Dictionary<ServiceControllerStatus, string>
    {
      { ServiceControllerStatus.ContinuePending, "Возобновление..." },
      { ServiceControllerStatus.Paused, "Приостановлена" },
      { ServiceControllerStatus.PausePending, "Приостановка..." },
      { ServiceControllerStatus.Running, "Запущена" },
      { ServiceControllerStatus.StartPending, "Запуск..." },
      { ServiceControllerStatus.Stopped, "Остановлена" },
      { ServiceControllerStatus.StopPending, "Остановка..." }
    };

    /// <summary>
    /// ctor.
    /// </summary>
    /// <param name="name">имя</param>
    public ServiceRecord(string name)
    {
      serviceName = name;
      ForceRefresh();
    }

    /// <summary>
    /// Принудительное обновление состояния.
    /// </summary>
    public void ForceRefresh()
    {
      controller =
        new List<ServiceController>(ServiceController.GetServices()).Find(
          s => string.Equals(s.ServiceName, serviceName, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Получение полного списка.
    /// </summary>
    /// <returns>список служб</returns>
    public static List<ServiceRecord> GetList()
    {
      var list = new List<ServiceRecord>();
      foreach (var service in ServiceController.GetServices())
        list.Add(new ServiceRecord(service.ServiceName));
      return list;
    }
  }
}
