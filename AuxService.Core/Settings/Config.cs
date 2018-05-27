using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using AuxService.Core.Service;
using Sef.Utility.Database;
using Sef.Utility.Xml;

namespace AuxService.Core.Settings
{
  /// <summary>
  /// Настройки.
  /// </summary>
  public class Config
  {
    #region Properties

    /// <summary>
    /// Минимальная степень сжатия при создании ZIP-архива.
    /// </summary>
    [XmlAttribute]
    public double CompressionRateMinimum
    { get; set; }

    /// <summary>
    /// Максимальная степень сжатия при создании ZIP-архива.
    /// </summary>
    [XmlAttribute]
    public double CompressionRateMaximum
    { get; set; }

    /// <summary>
    /// Задержка опроса принтера.
    /// </summary>
    [XmlAttribute]
    public int SpoolerTimer
    { get; set; }

    /// <summary>
    /// Задержка принтера до сохранения.
    /// </summary>
    [XmlIgnore]
    public const int SpoolerDelay = 30;

    /// <summary>
    /// Службы, за состоянием которых осуществляется наблюдение.
    /// </summary>
    [XmlArray("Services")]
    [XmlArrayItem("Service")]
    public List<string> ControlledServices
    { get; set; }

    /// <summary>
    /// Базы данных, которые нуждаются в резервировании.
    /// </summary>
    [XmlArray("Databases")]
    [XmlArrayItem("Database")]
    public List<DatabaseWrapper> Databases
    { get; set; }

    /// <summary>
    /// Время запуска обработки БД.
    /// </summary>
    [XmlAttribute]
    public DateTime ScheduleTime
    { get; set; }

    /// <summary>
    /// Папка, в которую сохраняются архивы.
    /// </summary>
    [XmlAttribute]
    public string OutputPath
    { get; set; }

    #endregion

    #region Const

    /// <summary>
    /// Путь к файлам журнала.
    /// </summary>
    public static readonly string LogPath = Path.Combine(Application.StartupPath, "Log");

    #endregion

    private Config()
    {
      ControlledServices = new List<string>();
      Databases = new List<DatabaseWrapper>();
    }

    /// <summary>
    /// Singleton.
    /// </summary>
    [XmlIgnore]
    public static Config Instance
    { get; private set; }

    #region Загрузка / сохранение

    // имя файла настроек
    private static readonly string fileName = Path.Combine(Application.StartupPath, "Config.xml");

    /// <summary>
    /// Загрузка значений по умолчанию.
    /// </summary>
    public void InitializeDefault()
    {
      CompressionRateMinimum = 0.1;
      CompressionRateMaximum = 0.5;
      SpoolerTimer = 10;
      OutputPath = @"F:\";
      ScheduleTime = new DateTime().AddHours(13).AddMinutes(5);
      ControlledServices.Clear();
      ControlledServices.AddRange(new[]
      {
        Constants.ServiceBdb,
        Constants.ServiceBdb2,
        Constants.ServiceAisurt,
        Constants.ClientServiceName,
        Constants.ServiceSql
      });
      Databases.Clear();
      Databases.AddRange(new[]
      {
        new DatabaseWrapper(ConnectionWrapper.CreateLoginPassword(string.Empty, "BaseComplex", "sa", string.Empty), true),
        new DatabaseWrapper(ConnectionWrapper.CreateLoginPassword(string.Empty, "BaseComplex2", "sa", string.Empty), true),
        new DatabaseWrapper(ConnectionWrapper.CreateLoginPassword(string.Empty, "AISURT", "BlankPublishAgent", "BlankPublishAgent"), false)
      });
    }

    /// <summary>
    /// Безопасная загрузка.
    /// </summary>
    public static void LoadOrCreate()
    {
      Config config;
      bool needSave = false;
      try
      {
        config = XmlHelper.Deserialize<Config>(fileName);
      }
      catch
      {
        config = new Config();
        config.InitializeDefault();
        needSave = true;
      }
      Instance = config;
      if (needSave)
        Save();
    }

    /// <summary>
    /// Безопасное сохранение.
    /// </summary>
    public static void Save()
    {
      XmlHelper.SerializeFile(Instance, fileName);
    }

    #endregion
  }
}
