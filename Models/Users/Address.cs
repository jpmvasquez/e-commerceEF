using System.ComponentModel.DataAnnotations;

namespace E_Commerce_Project.Models.Users;

public class Address
{
    public int id { get; set; }
    [Display(Name = "Numéro de voie")]
    [Required(ErrorMessage = "Le numéro de la voie est obligatoire")]
    [MaxLength(15)]
    public string streetNumber { get; set; }

    [Display(Name = "libellé de la voie")]
    [Required(ErrorMessage = "Le libellé de la voie est obligatoire")]
    [MaxLength(50)]
    public string streetName { get; set; }
    [Display(Name = "Ville")]
    [Required(ErrorMessage = "La ville est obligatoire")]
    [MaxLength(50)]
    public string city { get; set; }

    [Display(Name = "Code postal")]
    [Required(ErrorMessage = "Le code postal est obligatoire")]
    [MaxLength(5)]
    [DataType(DataType.PostalCode)]
       
    public string zipCode { get; set; }
    [Display(Name = "Pays")]
    [Required(ErrorMessage = "Le pays est obligatoire")]
    [MaxLength(50)]
    public string country { get; set; }

    public Address() { }
    public Address(string streetNumber, string streetName, string city, string zipCode, string country)
    {
        this.streetNumber = streetNumber;
        this.streetName = streetName;
        this.city = city;
        this.zipCode = zipCode;
        this.country = country;
    }
    public Address(int id, string streetNumber, string streetName, string city, string zipCode, string country)
    {
        this.id = id;
        this.streetNumber = streetNumber;
        this.streetName = streetName;
        this.city = city;
        this.zipCode = zipCode;
        this.country = country;
    }

    //public virtual List<Person>? Persons { get; set; }

    //public override string ToString()
    //{

    //    return(!);
    //}


}
