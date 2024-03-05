using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Shukaila_Lab3.Entities;

public class Journal
{
    private List<string> journal = new();

    public void AddEvent(string message)
    {
        journal.Add(message);
    }

    public void PrintEvents()
    {
        foreach (var item in journal)
        {
            Console.WriteLine(item);
        }
    }
}
