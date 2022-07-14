using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeesProj.Models.Entities
{
    public partial class Company
    {
        public Company()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }


        [Display(Name = "Company name")]
        [MinLength(1)]
        [MaxLength(30)]
        public string? CompanyName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
