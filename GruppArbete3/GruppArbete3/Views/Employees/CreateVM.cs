using System.ComponentModel.DataAnnotations;

namespace EmployeesProj.Views.Employees
{
    public class CreateVM
    {
        [Display(Name = "Name")]
        [MinLength(1)]
        [MaxLength(30)]
        [Required(ErrorMessage = "Name is a reqired field")]
        public string? Name { get; set; }

        [Display(Name = "E-mail")]
        [MinLength(1)]
        [MaxLength(255)]
        [EmailAddress]
        public string? Email { get; set; }

        public int CompanyId { get; set; }

    }
}
