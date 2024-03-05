using _253504_Shukaila_Lab5.Domain;

namespace _253504_Shukaila_Lab5;

public class Factory
{
    public string Name { get; set; } // Название завода
    public int ID { get; set; } // Идентификационный номер завода
    public List<Warehouse> Warehouses { get; set; } = new();

    // Конструктор класса
    public Factory(string name, int id, List<Warehouse> warehouses)
    {
        Name = name;
        ID = id;
        Warehouses = warehouses;
    }
    public Factory()
    {
        Name = "undefined";
        ID = 0;
        Warehouses = new();
    }

    public bool Equals(Factory other)
    {
        if(other == null) return false;
        return ID == other.ID && Name == other.Name;
    }
}