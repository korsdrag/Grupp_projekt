using EmployeesProj.Models.Entities;
using System.Text.Json;

namespace EmployeesProj.Models
{

    public class EmployeeService
    {

        EmployeesContext context;
        public EmployeeService(EmployeesContext context)
        {
            this.context = context;
        }

        public void Add(Employee employee)
        {
            context.Employees.Add(employee);   
            context.SaveChanges();
        }

        public Employee[] GetAll() => context.Employees.ToArray();

        public Employee GetById(int id) => context.Employees.Find(id);

    }
}