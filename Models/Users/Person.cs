using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static E_Commerce_Project.Models.Users.Person;

namespace E_Commerce_Project.Models.Users;

public class Person
{
    public enum eCivility
    {
        Monsieur,
        Madame
    }
    public enum eRole
    {
        Admin,
        Client
    }

    public int id { get; set; }
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

    [Display(Name = "mdp")]
    [Required(ErrorMessage = "Le mdp est obligatoire")]
    [DataType(DataType.Password)]
    public string password { get; set; }

    [Display(Name = "Confirmer le mdp")]
    [NotMapped]
    [Required(ErrorMessage = "Saisisser une nouvelle fois votre mdp")]
    [DataType(DataType.Password)]
    [Compare("password", ErrorMessage = "La deuxième saisie du mdp ne correspond pas à la première")]
    public virtual string confirmPassword { get; set; }
    public int addressId { get; set; }
    [ForeignKey("addressId")]
    public Address address { get; set; }
    public eRole role { get; set; } = eRole.Client;

    public Person (string firstName, string lastName, Address address, eRole role, 
        string emailAddress, eCivility civility, string password)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.address = address;
        this.role = role;
        this.emailAddress = emailAddress;
        this.civility = civility;
        this.password = password;
    }

    public Person(int id, string firstName, string lastName, Address address, eRole role,
        string emailAddress, eCivility civility, string Password)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        this.address = address;
        this.role = role;
        this.emailAddress = emailAddress;
        this.civility = civility;
        this.password = password;
    }

    public Person() { }
}