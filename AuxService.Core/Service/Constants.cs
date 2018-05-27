namespace AuxService.Core.Service
{
  /// <summary>
  /// Константы, используемые службами.
  /// </summary>
  public static class Constants
  {
    #region Служба клиента
    
    /// <summary>
    /// Имя службы клиента.
    /// </summary>
    public const string ClientServiceName = "AuxServiceClient";

    /// <summary>
    /// Отображаемое имя службы клиента.
    /// </summary>
    public const string ClientServiceDisplayName = "BlankPublish Auxiliary Service (client part)";

    /// <summary>
    /// Описание службы клиента.
    /// </summary>
    public const string ClientServiceDescription = "Многофункциональная вспомогательная служба (специально для РУП \"Издательство \"Белбланкавыд\"), клиентская часть";
    
    #endregion

    #region Управляемые службы

    /// <summary>
    /// Служба АС БДБ.
    /// </summary>
    public const string ServiceBdb = "BMRZ Service Container";

    /// <summary>
    /// Служба АМ КЗ.
    /// </summary>
    public const string ServiceBdb2 = "BDB2 Service Container";

    /// <summary>
    /// Служба АИС УРТ.
    /// </summary>
    public const string ServiceAisurt = "BlankPublishAgent";

    /// <summary>
    /// Служба SQL Server.
    /// </summary>
    public const string ServiceSql = "MSSQLSERVER";

    #endregion

    #region Потоки

    /// <summary>
    /// Поток: служба клиента.
    /// </summary>
    public const string ThreadClient = "Служба клиента";

    /// <summary>
    /// Поток: TCP-listener.
    /// </summary>
    public const string ThreadTcp = "TCP-сервер";
    
    /// <summary>
    /// Поток: Spooler watchdog.
    /// </summary>
    public const string ThreadSpooler = "Принтер";

    #endregion

    #region Журналы работы

    /// <summary>
    /// Журнал: основной.
    /// </summary>
    public const string LogService = "Service";

    /// <summary>
    /// Поток: принтер.
    /// </summary>
    public const string LogSpooler = "Spooler";

    #endregion
  }
}
