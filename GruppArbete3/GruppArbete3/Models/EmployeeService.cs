using EmployeesProj.Models.Entities;
using Microsoft.EntityFrameworkCore;

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

        public Employee[] GetAll() => context.Employees.Include("Company").ToArray();

        public Employee GetById(int id) => context.Employees.Find(id);

    }
}