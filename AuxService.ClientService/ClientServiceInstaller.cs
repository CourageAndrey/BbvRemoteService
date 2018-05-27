using System.ComponentModel;
using System.ServiceProcess;
using AuxService.Core.Service;
using Sef.Utility.Applications;

namespace AuxService.ClientService
{
  /// <summary>
  /// Installer для ClientService.
  /// </summary>
  [RunInstaller(true)]
  public sealed class ClientServiceInstaller : ServiceInstallerExt
  {
    /// <summary>
    /// ctor.
    /// </summary>
    public ClientServiceInstaller()
      : base(ServiceAccount.LocalSystem, ServiceStartMode.Automatic)
    { }

    /// <summary>
    /// Установка имён службы.
    /// </summary>
    /// <param name="installer">экземпляр установщика</param>
    protected override void PrepareNames(ServiceInstaller installer)
    {
      installer.ServiceName = Constants.ClientServiceName;
      installer.DisplayName = Constants.ClientServiceDisplayName;
      installer.Description = Constants.ClientServiceDescription;
    }
  }
}
