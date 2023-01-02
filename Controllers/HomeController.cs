using E_Commerce_Project.Data;
using E_Commerce_Project.Data.ViewComponents;
using E_Commerce_Project.Data.ViewModels;
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
        private readonly ILogger<HomeController> _logger;

        public static List<Product> _productsList = new List<Product>();
        public static List<Product> _selectedProductsList = new List<Product>();
        public static List<ShoppingBasketItem> _shoppingBasketItems = new List<ShoppingBasketItem>();
        public static ShoppingBasketSummary _shoppingBasketSummary = new ShoppingBasketSummary();
        public static ShoppingBasketVM _shoppingBasketVM = new ShoppingBasketVM();

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public async Task<IActionResult> IndexAsync()
        {
            //List<Product> productsList = Helper.getAllProducts();
            //_productsList = productsList;
            _productsList = _context
                .Product
                .Include(p => p.image)
                .Include(p => p.productDetails)
                .Include(p => p.productBrand)
                .Include(p => p.productTechno)
                .Include(p => p.productType)
                .ToList();
           var ReturnValue = _context
                .Product
                .Include(p => p.image)
                .Include(p => p.productDetails)
                .Include(p => p.productBrand)
                .Include(p => p.productTechno)
                .Include(p => p.productType)
                .ToListAsync();
            //foreach(Product productc in ReturnValue)
           // _productsList = ReturnValue;

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

        public IActionResult Filter(string searchString)
        {
            List<Product> filteredProductsList = new List<Product>();
            if (string.IsNullOrEmpty(searchString))
            {
                filteredProductsList.Clear();
                //return View("Index", _productsList);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                filteredProductsList = _productsList.Where(p => p.name.Contains(searchString)).ToList();
                return View("Index", filteredProductsList);
                //return View(filteredProductsList);
            }
        }

        public IActionResult AddProductToBasket(int productId)
        {
            if (_shoppingBasketItems.Where(s => s.product.id == productId).ToList().Count != 0)
            {
                _shoppingBasketItems.Where(s => s.product.id == productId).ToList()[0].qtyOrdered = _shoppingBasketItems.Where(s => s.product.id == productId).ToList()[0].qtyOrdered + 1;
            }
            else
            {
                if (_productsList.Where(p => p.id == productId).ToList().Count != 0)
                {
                    ShoppingBasketItem shppingBasketItem = new ShoppingBasketItem();
                    shppingBasketItem.product = _productsList.Where(p => p.id == productId).ToList()[0];
                    //selectedProductsList.Where(p => p.id == productId).ToList()[0].qtyOrdered = qtyOrdred = 1;
                    _shoppingBasketItems.Add(new ShoppingBasketItem()
                    {
                        product = _productsList.Where(p => p.id == productId).ToList()[0],
                        qtyOrdered = 1
                    });
                    //shoppingBasketItems.Where(p => p.id == productId).ToList()[0].qtyOrdered = selectedProductsList.Where(p => p.id == productId).ToList()[0].qtyOrdered + 1;
                }
            }
            _shoppingBasketSummary.shoppingBasketItems = _shoppingBasketItems;
            _shoppingBasketVM.shoppingBasketSummary = _shoppingBasketSummary;
            _shoppingBasketVM.totalPrice = _shoppingBasketSummary.GetShoppingBasketTotal();
            ViewBag.shoppingBasketVM = _shoppingBasketVM;
            ShoppingBasketSummary.populateShoppingBasketSummary(_shoppingBasketSummary);
            return View("Index", _productsList);
        }
    }
}