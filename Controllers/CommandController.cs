using E_Commerce_Project.Data;
using E_Commerce_Project.Data.ViewModels;
using E_Commerce_Project.Models.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Project.Controllers
{
    public class CommandController : Controller
    {
        private readonly AppDbContext _context;

        public static List<Product> _productsList = new List<Product>();
        public static List<Product> _selectedProductsList = new List<Product>();
        public static List<ShoppingBasketItem> _shoppingBasketItems = new List<ShoppingBasketItem>();
        public static ShoppingBasketSummary _shoppingBasketSummary = new ShoppingBasketSummary();
        public static ShoppingBasketVM _shoppingBasketVM = new ShoppingBasketVM();

        public CommandController(AppDbContext context)
        {
            _context = context;
            _productsList = _context
                .Product
                .Include(p => p.image)
                .Include(p => p.productDetails)
                .Include(p => p.productBrand)
                .Include(p => p.productTechno)
                .Include(p => p.productType)
                .ToList();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShoppingBasket()
        {
            _shoppingBasketSummary = ShoppingBasketSummary.getShoppingBasketSummary();
            _shoppingBasketVM.shoppingBasketSummary = _shoppingBasketSummary;
            _shoppingBasketVM.totalPrice = _shoppingBasketSummary.GetShoppingBasketTotal();
            return View("ShoppingBasketSumary", _shoppingBasketVM);
        }

        public IActionResult RemoveProdFromShoppingBasket(int id)
        {
            if (_shoppingBasketSummary.shoppingBasketItems.Where(s => s.product.id == id).ToList().Count != 0)
            {
                if (_shoppingBasketSummary.shoppingBasketItems.Where(s => s.product.id == id).ToList()[0].qtyOrdered == 1)
                    _shoppingBasketSummary.shoppingBasketItems.Remove(_shoppingBasketSummary.shoppingBasketItems.Where(s => s.product.id == id).ToList()[0]);
                else
                    _shoppingBasketSummary.shoppingBasketItems.Where(s => s.product.id == id).ToList()[0].qtyOrdered = _shoppingBasketSummary.shoppingBasketItems.Where(s => s.product.id == id).ToList()[0].qtyOrdered - 1;
            }

            _shoppingBasketVM.shoppingBasketSummary = _shoppingBasketSummary;
            _shoppingBasketVM.totalPrice = _shoppingBasketSummary.GetShoppingBasketTotal();
            ViewBag.shoppingBasketVM = _shoppingBasketVM;

            return View("ShoppingBasketSumary", _shoppingBasketVM);
        }

        public IActionResult AddProdToShoppingBasket(int id)
        {
            if (_shoppingBasketSummary.shoppingBasketItems.Where(s => s.product.id == id).ToList().Count != 0)
                _shoppingBasketSummary.shoppingBasketItems.Where(s => s.product.id == id).ToList()[0].qtyOrdered = _shoppingBasketSummary.shoppingBasketItems.Where(s => s.product.id == id).ToList()[0].qtyOrdered + 1;

            _shoppingBasketVM.shoppingBasketSummary = _shoppingBasketSummary;
            _shoppingBasketVM.totalPrice = _shoppingBasketSummary.GetShoppingBasketTotal();
            ViewBag.shoppingBasketVM = _shoppingBasketVM;
            ShoppingBasketSummary.populateShoppingBasketSummary(_shoppingBasketSummary);

            return View("ShoppingBasketSumary", _shoppingBasketVM);
        }
    }
}
