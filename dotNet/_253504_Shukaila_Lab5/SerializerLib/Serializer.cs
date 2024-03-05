using System.Xml.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using _253504_Shukaila_Lab5.Domain;
using _253504_Shukaila_Lab5;
using System.Xml;

namespace SerializerLib;
public class Serializer : ISerializer
{
    public void SerializeByLINQ(IEnumerable<CCC> xxx, string fileName)
    {
        XElement rootElement = new XElement("Data");
        foreach (var item in xxx)
        {
            //Создаем элементы для каждого объекта ССС
            XElement cccElement = new XElement("CCC");

            //Добавляем данные объекта ССС в элемент
            foreach (var fact in item.Factories)
            {
                XElement factElement = new XElement("Factory",
                    new XElement("FactoryID", fact.ID),
                    new XElement("FactoryName", fact.Name)
                );

                foreach (var storage in fact.Warehouses)
                {
                    XElement storageElement = new XElement("Warehouse",
                        new XElement("WarehouseID", storage.ID)
                        );
                    foreach (var detail in storage.Details)
                    {
                        XElement detailElement = new XElement("Detail",
                            new XElement("DetailName", detail.Name),
                            new XElement("DetailType", detail.Type),
                            new XElement("DetailCost", detail.Cost)
                        );
                        storageElement.Add(detailElement);
                    }
                    cccElement.Add(storageElement);
                }
                cccElement.Add(factElement);
            }
            rootElement.Add(cccElement);
        }
        //Создаем документ и сохраняем его в файл
        XDocument document = new XDocument(rootElement);
        document.Save(fileName);
    }

    public IEnumerable<CCC> DeSerializeByLINQ(string fileName)
    {
        List<CCC> result = new List<CCC>();
        //Загрузка xml документа из файла
        XDocument document = XDocument.Load(fileName);

        //Используем linq-to-xml для извлечения данных
        var cccElements = document.Descendants("CCC");
        foreach (var cccelem in cccElements)
        {
            var factoryElements = cccelem.Descendants("Factory");
            var storageElements = cccelem.Descendants("Warehouse");

            CCC ccc = new();

            foreach (var factoryelem in factoryElements)
            {
                int factoryID = int.Parse(factoryelem.Element("FactoryID").Value);
                string factName = factoryelem.Element("FactoryName").Value;
                List<Warehouse> warehouses = new List<Warehouse>();
                Factory factory = new Factory(factName, factoryID, warehouses);

                foreach (var storageelem in storageElements)
                {
                    int storageID = int.Parse(storageelem.Element("WarehouseID").Value);
                    Warehouse storage = new Warehouse(storageID);
                    var detailElements = storageelem.Descendants("Detail");
                    foreach (var detailelem in detailElements)
                    {
                        string detailName = detailelem.Element("DetailName").Value;
                        string type = detailelem.Element("DetailType").Value;
                        decimal cost = decimal.Parse(detailelem.Element("DetailCost").Value);
                        Detail detail = new Detail(detailName, type, cost);
                        storage.Details.Add(detail);
                    }
                    factory.Warehouses.Add(storage);
                }
                ccc.Factories.Add(factory);
            }
            result.Add(ccc);
        }
        return result;
    }

    public void SerializeXML(IEnumerable<CCC> data, string fileName)
    {
        var serializer = new XmlSerializer(typeof(List<CCC>));
        using (StreamWriter file = File.CreateText(fileName))
        {
            serializer.Serialize(file, data);
        }
    }

    public IEnumerable<CCC> DeSerializeXML(string fileName)
    {
        if (File.Exists(fileName))
        {
            var serializer = new XmlSerializer(typeof(List<CCC>));
            using (StreamReader file = File.OpenText(fileName))
            {
                return (List<CCC>)serializer.Deserialize(file);
            }
        }
        else
        {
            throw new FileNotFoundException($"File not found: {fileName}");
        }
    }

    public void SerializeJSON(IEnumerable<CCC> data, string fileName)
    {
        var json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(fileName, json);
    }

    public IEnumerable<CCC> DeSerializeJSON(string fileName)
    {
        if (File.Exists(fileName))
        {
            var json = File.ReadAllText(fileName);
            return JsonConvert.DeserializeObject<List<CCC>>(json);
        }
        else
        {
            throw new FileNotFoundException($"File not found: {fileName}");
        }
    }
}