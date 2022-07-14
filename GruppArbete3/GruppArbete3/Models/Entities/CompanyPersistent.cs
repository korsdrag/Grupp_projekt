using System;
using System.Collections.Generic;

namespace EmployeesProj.Models.Entities
{
    public partial class Company
    {
        public override string ToString()
        {
            return $"{CompanyName}";
        }
    }
}
