using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce_Project.Models.Products
{
    public class Image
    {
        public int id { get; set; } 
        public string name { get; set; }
        public string title { get; set; }
        [NotMapped]
        public virtual IFormFile formFile { get; set; }
        
        public Image(){ }
        public Image(int id, string name, string title, IFormFile formFile)
        {
            this.id = id;
            this.name = name;
            this.title = title;
            this.formFile = formFile;
        }
        public Image(string name, string title, IFormFile formFile)
        {
            this.name = name;
            this.title = title;
            this.formFile = formFile;
        }
    }
}
