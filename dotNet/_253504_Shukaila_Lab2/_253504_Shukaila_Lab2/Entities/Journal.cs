
using _253504_Shukaila_Lab2.Collections;

namespace _253504_Shukaila_Lab2.Entities;

public class Journal
{
    private MyList<string> journal = new();

    public void AddEvent(string message)
    {
        journal.Add(message);
    }

    public void PrintEvents()
    {
        foreach(var item in journal)
        {
            Console.WriteLine(item);
        }
    }
}
