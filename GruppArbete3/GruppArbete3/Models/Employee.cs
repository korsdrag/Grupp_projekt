using System.ComponentModel.DataAnnotations;

namespace GruppArbete3.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [MinLength(1)]
        [MaxLength(30)]
        [Required(ErrorMessage = "Name is a reqired field")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [MinLength(1)]
        [MaxLength(255)]
        [Required(ErrorMessage = "E-mail is a required field")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
