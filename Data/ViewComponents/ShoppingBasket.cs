using Microsoft.AspNetCore.Mvc;
using E_Commerce_Project.Models.Products;
using E_Commerce_Project.Data.ViewModels;

namespace E_Commerce_Project.Data.ViewComponents;
public class ShoppingBasket : ViewComponent
{

    //public static List<Product> _selectedProds = new List<Product>();
    //public async Task<IViewComponentResult> InvokeAsync()
    //{
    //    if (ViewBag.selectedProds != null)
    //        _selectedProds = ViewBag.selectedProds;

    //    return View("ShoppingBasket", _selectedProds);
    //}

    public static ShoppingBasketVM _shoppingBasketVM = new ShoppingBasketVM();
    public async Task<IViewComponentResult> InvokeAsync()
    {
        if (ViewBag.shoppingBasketVM != null)
            _shoppingBasketVM = ViewBag.shoppingBasketVM;

        return View("ShoppingBasket", _shoppingBasketVM);
    }
}
