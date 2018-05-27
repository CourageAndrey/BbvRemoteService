namespace AuxService.Core.Transfer
{
  /// <summary>
  /// Статический класс, описывающий правила взаимодействия клиентской и серверной частей.
  /// </summary>
  public static class Protocol
  {
    /// <summary>
    /// Сигнатура запроса оборудования.
    /// </summary>
    public const string GetHardSign = "#REQH";

    /// <summary>
    /// Сигнатура запроса состояния.
    /// </summary>
    public const string GetStatusSign = "#REQS";

    /// <summary>
    /// Сигнатура запроса версий.
    /// </summary>
    public const string GetVersionsSign = "#REQV";

    /// <summary>
    /// Сигнатура запроса журналов.
    /// </summary>
    public const string GetLogsSign = "#REQL";

    /// <summary>
    /// Сигнатура запроса траффика.
    /// </summary>
    public const string GetTrafficSign = "#REQT";

    /// <summary>
    /// Сигнатура запроса логов принтера.
    /// </summary>
    public const string GetPrintedSign = "#REQP";

    /// <summary>
    /// Сигнатура правильного конца пакета.
    /// </summary>
    public const string EndSign = "#END!";

    /// <summary>
    /// Используемый размер буффера.
    /// </summary>
    /// <remarks>по умолчанию - 4 Кб</remarks>
    public const int BufferSize = 4 * 1024;

    /// <summary>
    /// Порт для обмена данными клиент-сервер.
    /// </summary>
    public const int ConnectionPort = 1987;

    /// <summary>
    /// Определение, являеются ли пришедшие данные заархивированными.
    /// </summary>
    /// <param name="data">данные</param>
    /// <returns><b>true</b>, если архив</returns>
    public static bool IsArchive(byte[] data)
    {
      // пакет должен начинаться с ASCII-символов "PK"
      return (data.Length > 2) && (data[0] == 80) && (data[1] == 75);
    }
  }
}
