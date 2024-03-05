using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _253504_Shuakilka_Lab4.Entities;
using Interfaces;
internal class FileService : IFileService<Employee>
{
    public IEnumerable<Employee> ReadFile(string fileName)
    {
        using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                int employeeId = reader.ReadInt32();
                string name = reader.ReadString();
                bool isManager = reader.ReadBoolean();
                yield return new Employee { ID = employeeId, Name = name, IsActive = isManager };
            }
        }
    }

    public void SaveData(IEnumerable<Employee> data, string fileName)
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
        {
            foreach (var employee in data)
            {
                writer.Write(employee.ID);
                writer.Write(employee.Name);
                writer.Write(employee.IsActive);
            }
        }
    }
}
