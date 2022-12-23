using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using static E_Commerce_Project.Models.Users.Person;
using E_Commerce_Project.Models;

namespace E_Commerce_Project.Data.ViewModels
{
    public class UserRegistrationVM
    {
        [Display(Name = "civilité")]
        [Required(ErrorMessage = "La Civilité est obligatoire")]
        public eCivility civility { get; set; }
        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        public string firstName { get; set; }

        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le nom est obligatoire")]
        public string lastName { get; set; }

        [Display(Name = "Adresse Email")]
        [Required(ErrorMessage = "L'Adresse Email est obligatoire")]
        public string emailAddress { get; set; }

        [Required(ErrorMessage = "Le mdp est obligatoire")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Confirmer le mdp")]
        [Required(ErrorMessage = "Saisisser une nouvelle fois votre mdp")]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "La deuxième saisie du mdp ne correspond pas à la première")]
        public string confirmPassword { get; set; }
    }
}
