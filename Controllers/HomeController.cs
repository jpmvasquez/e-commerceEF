using E_Commerce_Project.Data;
using E_Commerce_Project.Models;
using E_Commerce_Project.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace E_Commerce_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        private readonly ILogger<HomeController> _logger;
        public static List<Product> _productsList = new List<Product>();
        public static List<Product> selectedProductsList = new List<Product>();

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public async Task<IActionResult> IndexAsync()
        {
            //List<Product> productsList = Helper.getAllProducts();
            //_productsList = productsList;
            var ReturnValue = _context
                .Product
                .Include(p => p.image)
                .Include(p => p.productDetails)
                .Include(p => p.productBrand)
                .Include(p => p.productTechno)
                .Include(p => p.productType)
                .ToListAsync();

            return View(await ReturnValue);
            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Home()
        {
            //List<Product> productsList = Helper.getAllProducts();
            //_productsList = productsList;
            return View();
        }

        
    }
}