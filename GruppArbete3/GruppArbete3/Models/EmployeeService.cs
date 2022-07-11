using System.Text.Json;

namespace GruppArbete3.Models
{

    public class EmployeeService
    {

        string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Employee.json");

        private List<Employee> ReadEmployees()
        {

            var content = File.ReadAllText(filename);
            return content == String.Empty ? new List<Employee>() : JsonSerializer.Deserialize<List<Employee>>(content);

        }
        static List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = 1,
                Name = "Gabriel",
                Email = "Gabriel@tengens.se"
            }
        };

        public void Add(Employee employee)
        {
            var employees = ReadEmployees();

            if (employees.Count == 0)
                employee.Id = 1;
            else
                employee.Id = employees.Max(x => x.Id) + 1;


            employees.Add(employee);
            string json = JsonSerializer.Serialize(employees);
            File.WriteAllText(filename, json);
        }

        public Employee[] GetAll() => ReadEmployees().ToArray();

        public Employee GetById(int id) => employees.SingleOrDefault(e => e.Id == id);
        
    }
}