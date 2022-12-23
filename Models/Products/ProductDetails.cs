using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Project.Models.Products;

public class ProductDetails
{
    public int id { get; set; }
    [Display(Name = "Image du produit")]
    [Required(ErrorMessage = "L'image du produit est obligatoire")]
    public int resolution { get; set; }
    public string zoomOptic { get; set; }
    public string video { get; set; }
    public bool stabilisator { get; set; }
    public int isoMax { get; set; }

    

    public ProductDetails(int id, int resolution, string zoomOptic, string video, bool stabilisator, int isoMax)
    {
        this.id = id;
        this.resolution = resolution;
        this.zoomOptic = zoomOptic;
        this.video = video;
        this.stabilisator = stabilisator;
        this.isoMax = isoMax;
    }
    public ProductDetails(int resolution, string zoomOptic, string video, bool stabilisator, int isoMax)
    {
        this.resolution = resolution;
        this.zoomOptic = zoomOptic;
        this.video = video;
        this.stabilisator = stabilisator;
        this.isoMax = isoMax;
    }
    public ProductDetails()
    {
    }

}

