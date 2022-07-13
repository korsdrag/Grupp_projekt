using System;
using System.Collections.Generic;

namespace EmployeesProj.Models.Entities
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public int? CompanyId { get; set; }
    }
}
