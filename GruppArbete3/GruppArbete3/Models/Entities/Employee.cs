using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeesProj.Models.Entities
{
    public partial class Employee
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [MinLength(1)]
        [MaxLength(30)]
        [Required(ErrorMessage = "Name is a reqired field")]
        public string Name { get; set; } = null!;

        [Display(Name = "E-mail")]
        [MinLength(1)]
        [MaxLength(255)]
        [EmailAddress]
        public string? Email { get; set; }

        public int? CompanyId { get; set; }

        public virtual Company? Company { get; set; }

    }
}
