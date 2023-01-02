using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace E_Commerce_Project.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Adresse email")]
        [Required(ErrorMessage = "L'adress email est obligatoire")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
