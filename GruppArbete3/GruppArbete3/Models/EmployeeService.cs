using EmployeesProj.Models.Entities;
using EmployeesProj.Views.Employees;
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

        public void PostCreate(CreateVM model)
        {
            context.Employees.Add(new Employee { Name = model.Name, Email = model.Email, CompanyId = model.CompanyId});   
            context.SaveChanges();
        }

        public void PostCompany(AddCompanyVM model)
        {
            context.Companies.Add(new Company { CompanyName = model.CompanyName});   
            context.SaveChanges();
        }

        public void PostRemoveEmployee(int id)
        {
            context.Employees.Remove(GetEmployeeById(id));
            context.SaveChanges();
        }

        //internal void PostRemoveCompany(int id)
        //{
        //    context.Companies.Remove(GetCompanyById(id));
        //    context.SaveChanges();
        //}

        public Employee GetEmployeeById(int id) => context.Employees.Find(id);
        
        public Company GetCompanyById(int id) => context.Companies.Find(id);

        public IndexVM[] GetEmployeeIndex() => context.Employees.Include(o => o.Company).Select(o => new IndexVM { Id = o.Id, EmployeeName = o.Name, CompanyName = o.Company.CompanyName }).ToArray();
        
        public ListCompaniesVM[] GetCompanyIndex() => context.Companies.Select(o => new ListCompaniesVM { Id = o.Id, CompanyName = o.CompanyName }).ToArray();

        public DetailsVM GetEmployeeDetails(int id) => context.Employees.Include(o => o.Company).Where(o => o.Id == id).Select(o => new DetailsVM{ EmployeeName = o.Name, EmployeeEmail = o.Email, CompanyName = o.Company.CompanyName }).Single();

        internal CompanyDetailsVM GetCompanyDetails(int id) => context.Companies.Include(o => o.Employees).Where(o => o.Id == id).Select(o => new CompanyDetailsVM { CompanyName = o.CompanyName, Id = o.Id, NumberOfEmployees = o.Employees.Where(o => o.CompanyId == id).Count() }).Single();

    }
}