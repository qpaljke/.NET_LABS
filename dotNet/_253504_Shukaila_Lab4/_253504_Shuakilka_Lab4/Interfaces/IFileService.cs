using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253504_Shuakilka_Lab4.Interfaces;

internal interface IFileService<Employee>
{
    IEnumerable<Employee> ReadFile(string fileName);
    void SaveData(IEnumerable<Employee> data, string fileName);
}
