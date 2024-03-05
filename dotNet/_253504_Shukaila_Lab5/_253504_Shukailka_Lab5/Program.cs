namespace _253504_Shukailka_Lab5;

using _253504_Shukaila_Lab5;
using _253504_Shukaila_Lab5.Domain;
using Newtonsoft.Json;
using SerializerLib;
internal class Program
{
    static void Main(string[] args)
    {
        List<CCC> dataList = new List<CCC>
        {
            new CCC
            {
                Factories = new List<Factory>
                {
                    new Factory
                    {
                        Name = "Factory1",
                        ID = 1,
                        Warehouses = new List<Warehouse>
                        {
                             new Warehouse
                             {
                                 ID = 101,
                                 Details = new List<Detail>
                                 {
                                     new Detail
                                     {
                                         Name = "Detail1",
                                         Type = "Type1",
                                         Cost = 10.0m },

                                     new Detail
                                     {
                                         Name = "Detail2",
                                         Type = "Type2",
                                         Cost = 15.0m
                                     }
                                 }
                             },
                             new Warehouse
                             {
                                 ID = 102,
                                 Details = new List<Detail>
                                 {
                                     new Detail
                                     {
                                         Name = "Detail3",
                                         Type = "Type3",
                                         Cost = 20.0m
                                     },
                                     new Detail
                                     {
                                         Name = "Detail4",
                                         Type = "Type4",
                                         Cost = 25.0m
                                     }
                                 }
                             }
                        }
                    }
                }
            }
        };

        Serializer serializer = new Serializer();

        // Serialize to XML
        serializer.SerializeXML(dataList, "data.xml");
        //Console.WriteLine("Data has been serialized to XML.");

        // Deserialize from XML
        var deserializedDataXML = serializer.DeSerializeXML("data.xml");
        //Console.WriteLine("Data has been deserialized from XML:");
        //PrintCCCList(deserializedDataXML);

        // Serialize to JSON
        serializer.SerializeJSON(dataList, "data.json");
        Console.WriteLine("Data has been serialized to JSON.");

        // Deserialize from JSON
        var deserializedDataJSON = serializer.DeSerializeJSON("data.json");
        //Console.WriteLine("Data has been deserialized from JSON:");
        //PrintCCCList(deserializedDataJSON);





        string fileName = "data.json"; // Replace with the path to your JSON file

        if (File.Exists(fileName))
        {
            string json = File.ReadAllText(fileName);
            var deserializedData = JsonConvert.DeserializeObject(json);

            Console.WriteLine("Contents of the JSON file:");
            Console.WriteLine(json);
        }
        else
        {
            Console.WriteLine($"File not found: {fileName}");
        }

    }

    static void PrintCCCList(IEnumerable<CCC> data)
    {
        foreach (var ccc in data)
        {
            Console.WriteLine($"CCC object:");
            foreach (var factory in ccc.Factories)
            {
                Console.WriteLine($"  Factory: Name - {factory.Name}, ID - {factory.ID}");

                foreach (var storage in factory.Warehouses)
                {
                    Console.WriteLine($"  Storage: ID - {storage.ID}");
                    foreach (var detail in storage.Details)
                    {
                        Console.WriteLine($"    Detail: Name - {detail.Name}, Type - {detail.Type}, Cost - {detail.Cost}");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}