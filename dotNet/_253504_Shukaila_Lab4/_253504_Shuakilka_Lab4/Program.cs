using _253504_Shuakilka_Lab4.Entities;

namespace _253504_Shuakilka_Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string folderPath = "Shukaila_Lab4";
            Directory.CreateDirectory(folderPath);

            Random random = new Random();
            string[] extensions = { ".txt", ".rtf", ".dat", ".inf" };

            for (int i = 1; i <= 10; i++)
            {
                string randomFileName = Path.Combine(folderPath, $"File{i}{extensions[random.Next(extensions.Length)]}");
                File.Create(randomFileName).Close();
            }

            Console.WriteLine("Список файлов в папке:");
            string[] fileEntries = Directory.GetFiles(folderPath);
            foreach (string fileName in fileEntries)
            {
                string extension = Path.GetExtension(fileName);
                Console.WriteLine($"Файл: {Path.GetFileName(fileName)} имеет расширение {extension}");
            }

            List<Employee> employees = new List<Employee>
            {
                new Employee { ID = 1, Name = "John", IsActive = true },
                new Employee { ID = 2, Name = "Alice", IsActive = false },
                new Employee { ID = 3, Name = "Bob", IsActive = true },
                new Employee { ID = 4, Name = "Eve", IsActive = false },
                new Employee { ID = 5, Name = "Charlie", IsActive = true },
            };

            string employeeFileName = Path.Combine(folderPath, "Employees.dat");
            FileService fileService = new FileService();
            fileService.SaveData(employees, employeeFileName);

            string newEmployeeFileName = Path.Combine(folderPath, "NewEmployees.txt");
            File.Move(employeeFileName, newEmployeeFileName);

            List<Employee> newEmployees = fileService.ReadFile(newEmployeeFileName).ToList();
            newEmployees.Sort(new MyCustomComparer());

            Console.WriteLine("\nИсходная коллекция сотрудников:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"Имя: {employee.Name}, Менеджер: {employee.IsActive}");
            }

            Console.WriteLine("\nОтсортированная коллекция сотрудников:");
            foreach (var employee in newEmployees)
            {
                Console.WriteLine($"Имя: {employee.Name}, Менеджер: {employee.IsActive}");
            }

            var sortedEmployeesByEmployeeId = newEmployees.OrderBy(e => e.ID).ToList();
            Console.WriteLine("\nОтсортированная коллекция сотрудников по EmployeeId:");
            foreach (var employee in sortedEmployeesByEmployeeId)
            {
                Console.WriteLine($"Имя: {employee.Name}, Менеджер: {employee.IsActive}, EmployeeId: {employee.ID}");
            }

        }
    }
}