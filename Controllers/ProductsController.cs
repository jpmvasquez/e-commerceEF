using E_Commerce_Project.Data;
using E_Commerce_Project.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.RegularExpressions;

namespace E_Commerce_Project.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        public IWebHostEnvironment _hostEnvironment;
        public static List<SelectListItem> brandsList;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> IndexAsync()
        {
            //brandsList = _context.Brand.ToListAsync();
            //ViewData.Add("brandsList", brandsList);
            //ViewBag.brandsList = brandsList;
            ViewData["IdBrand"] = new SelectList(
                _context.Brand, "id", "name");
            ViewData["IdTechno"] = new SelectList(
                _context.Techno, "id", "name");
            ViewData["IdType"] = new SelectList(
                _context.ProductType, "id", "name");
            return View();
        }

        //public IActionResult AddNewProduct()
        //{
        //    //Product product = new Product();

        //    brandsList = new Brands().brandsList;
        //    ViewData.Add("brandsList", brandsList);
        //    ViewBag.brandsList = brandsList;
        //    return View();
        //}



        //[HttpPost]
        //public IActionResult AddNewProduct(Product product, [FromServices] IWebHostEnvironment _hostEnvironment)
        //{
        //    //string wwwRootPath = _hostEnvironment.WebRootPath;
        //    Helper.addNewProductToDb(product, _hostEnvironment);
        //    //Product? product;
        //    return View("Home/Index");
        //}
        public IActionResult AddNewProduct()
        {
            ViewData["IdBrand"] = new SelectList(
                _context.Brand, "id", "name");
            ViewData["IdTechno"] = new SelectList(
                _context.Techno, "id", "name");
            ViewData["IdType"] = new SelectList(
                _context.ProductType, "id", "name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNewProduct([Bind("Id,Number,Name,Technology,IdProject")] Product @product)
        {
            //[Bind("Id,Number,Name,Technology,IdProject")] Image @image;
            if (ModelState.IsValid)
            {
                _context.Add(@product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["idTechno"] = new SelectList(
                _context.Techno, "Id", "Name");
            ViewData["idBrand"] = new SelectList(
                _context.Brand, "Id", "Name");
            ViewData["idType"] = new SelectList(
                _context.ProductType, "Id", "Name");
            return View(@product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Product product, [FromServices] IWebHostEnvironment _hostEnvironment)
        {
            //string wwwRootPath = _hostEnvironment.WebRootPath;
            //Helper.addNewProductToDb(product, _hostEnvironment);
            //Product? product;
            return View("Home/Index");
        }
        //[HttpPost]
        //public IActionResult Index(Product product, [FromServices] IWebHostEnvironment _hostEnvironment)
        //{
        //    //string wwwRootPath = _hostEnvironment.WebRootPath;
        //    Helper.addNewProductToDb(product, _hostEnvironment);
        //    //Product? product;
        //    return View("Home/Index");
        //}
    }
}
