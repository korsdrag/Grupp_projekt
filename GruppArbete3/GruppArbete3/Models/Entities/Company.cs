using System;
using System.Collections.Generic;

namespace EmployeesProj.Models.Entities
{
    public partial class Company
    {
        public Company()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string? CompanyName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
       
        public override string ToString()
        {
            return $"{CompanyName}";
        }
    }

}
