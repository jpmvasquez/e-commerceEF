using E_Commerce_Project.Models.Products;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SqlClient;

namespace E_Commerce_Project.Data
{
    public class Brands
    {
        //public List<Brand> brandsList = new List<Brand>();
        private readonly AppDbContext _context;
        public List<SelectListItem> brandsList = new List<SelectListItem>();
        public Brands(AppDbContext context)
        {
            _context = context;
            /*this.brandsList = */
            fillBrandsList(brandsList, _context);
        }

        public /*List<Brand>*/void fillBrandsList(List<SelectListItem> brandsList, AppDbContext context)
        {
            //_context.Brand.
            //SqlConnection sqlConnection = Helper.dbConnection();
            //Helper.getAllBrands(sqlConnection, brandsList);
            //return brandsList;
        }
    }
}
