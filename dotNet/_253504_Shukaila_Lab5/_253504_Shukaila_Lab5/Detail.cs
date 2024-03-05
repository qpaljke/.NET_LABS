using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Shukaila_Lab5.Domain;

public class Detail
{
    public string Name { get; set; } // Название детали
    public string Type { get; set; } // Тип детали
    public decimal Cost { get; set; } // Стоимость детали

    // Конструктор
    public Detail(string name, string type, decimal cost)
    {
        Name = name;
        Type = type;
        Cost = cost;
    }
    public Detail()
    {
        Name = "undefined";
        Type = "undefined";
        Cost = 0;
    }
    public bool Equals(Detail other)
    {
        if (other == null) return false;
        return Name == other.Name && Type == other.Type && Cost == other.Cost;
    }
}
