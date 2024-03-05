using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Shukaila_Lab5.Domain;

public class Warehouse
{
    public int ID { get; set; }
    public List<Detail> Details = new(); // Список хранящихся деталей

    public Warehouse()
    {
        ID = 0;
    }
    public Warehouse(int Id) 
    {
        ID = Id;
    }
    // Метод для добавления детали на склад
    public void AddPartToWarehouse(Detail detail)
    {
        Details.Add(detail);
    }

    // Метод для удаления детали со склада
    public void RemovePartFromWarehouse(Detail detail)
    {
        Details.Remove(detail);
    }
    public bool Equals(Warehouse other)
    {
        return ID == other.ID && Details.SequenceEqual(other.Details);
    }
}   
