using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Project.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Adresse Email")]
        [Required(ErrorMessage = "L'adresse Email est obligatoire")]
        public string emailAddress { get; set; }

        [Required(ErrorMessage = "Le mdp est obligatoire")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
