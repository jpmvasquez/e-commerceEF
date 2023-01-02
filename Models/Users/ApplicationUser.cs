using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Project.Models.Users
{
    public class ApplicationUser : IdentityUser
    {
        public enum eCivility
        {
            Monsieur,
            Madame
        }

        [Required(ErrorMessage = "La civilité est obligatoire")]
        [Display(Name = "Civilité")]
        public eCivility civility { get; set; }
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [Display(Name = "Prénom")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Le nom de famille est obligatoire")]
        [Display(Name = "Nom de famille")]
        public string lastName { get; set; }
        public string fullName => firstName + " " + lastName;
        [Required]
        public int addressId { get; set; }
        [ForeignKey("addressId")]
        [NotMapped]
        public Address address { get; set; }

        public ApplicationUser() { }
    }

}
