using System.Collections.Generic;
using System.Linq;

namespace AuxService.Core.SalePoints
{
  /// <summary>
  /// Пункт реализации.
  /// </summary>
  public class SalePoint
  {
    #region Свойства

    /// <summary>
    /// Идентификатор в базе.
    /// </summary>
    public long ID
    { get; private set; }

    /// <summary>
    /// Код.
    /// </summary>
    public string Code
    { get; private set; }

    /// <summary>
    /// Наименование.
    /// </summary>
    public string Name
    { get; private set; }

    /// <summary>
    /// Область.
    /// </summary>
    public string Region
    { get; private set; }

    /// <summary>
    /// IP-адрес, по которому можно подключиться.
    /// </summary>
    public string IP
    { get; private set; }

    /// <summary>
    /// Адрес.
    /// </summary>
    public List<string> Address
    { get; private set; }

    /// <summary>
    /// Контактные данные.
    /// </summary>
    public List<string> Contacts
    { get; private set; }

    /// <summary>
    /// Продавцы.
    /// </summary>
    public List<string> Persons
    { get; private set; }

    #endregion

    /// <summary>
    /// ctor.
    /// </summary>
    public SalePoint()
    {
      Contacts = new List<string>();
      Persons = new List<string>();
    }

    /// <summary>
    /// Загрузка данных.
    /// </summary>
    /// <param name="xml">запись в XML</param>
    /// <param name="sql">список записей в SQL</param>
    /// <param name="regions">список регионов</param>
    /// <param name="persons">список должностных лиц</param>
    /// <param name="contacts">список контактов</param>
    /// <param name="old">список старых</param>
    /// <returns>полноценный ПР</returns>
    public static SalePoint LoadInfo(SalePointRecordXml xml, List<SalePointRecordSql> sql, List<Region> regions, List<Person> persons, List<Contact> contacts, List<SalePoint> old)
    {
      var salePoint = new SalePoint();

      // код и IP берутся из XML
      salePoint.Code = xml.Code;
      salePoint.IP = xml.IP;

      if (old.Count == 0)
      {
        // ищем запись из БД и читаем её свойства
        var sp = sql.Find(record => record.Code == salePoint.Code);
        salePoint.ID = sp.ID;
        salePoint.Name = sp.Name;
        salePoint.Address = new List<string> { sp.Address };
        salePoint.Region = regions.Find(r => r.ID == sp.Region).Name;
        foreach (var contact in contacts.Where(c => c.SalePoint == salePoint.ID))
          salePoint.Contacts.AddRange(contact.Telephones);
        foreach (var person in persons.Where(c => c.SalePoint == salePoint.ID))
          salePoint.Persons.Add(string.Format("{0} {1}", person.Position, person.FIO));
      }
      else
      {
        salePoint.ID = old[0].ID;
        salePoint.Name = string.Format("{0} (компьютер №{1})", old[0].Name, old.Count + 1);
        salePoint.Region = old[0].Region;
      }

      return salePoint;
    }
  }
}
