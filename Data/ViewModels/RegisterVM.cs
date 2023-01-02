using E_Commerce_Project.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;
using static E_Commerce_Project.Models.Users.ApplicationUser;

namespace E_Commerce_Project.Data.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "La civilité est obligatoire")]
        [Display(Name = "Civilité")]
        public eCivility civility { get; set; }
        [Display(Name = "Prénom")]
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        public string firstName { get; set; }

        [Display(Name = "Nom de Famille")]
        [Required(ErrorMessage = "Le nom de famille est  obligatoire")]
        public string lastName { get; set; }
        public string fullName => firstName + " " + lastName;

        [Display(Name = "Adresse email")]
        [Required(ErrorMessage = "L'adress email est obligatoire")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmer le mdp")]
        [Required(ErrorMessage = "La confirmation du mdp est obligatoire")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les mdp ne sont pas identiques")]
        public string ConfirmPassword { get; set; }

        [Required]
        public int addressId { get; set; }
        [ForeignKey("addressId")]
        [NotMapped]
        public Address address { get; set; }
    }
}
