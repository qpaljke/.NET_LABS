using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Shuakilka_Lab4.Entities
{
    internal class MyCustomComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        }
    }
}
