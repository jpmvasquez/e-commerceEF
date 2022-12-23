using Microsoft.AspNetCore.Mvc;
using E_Commerce_Project.Models.Products;

namespace E_Commerce_Project.Data.ViewComponents;
public class ShoppingBasket : ViewComponent
{

    public static List<Product> _selectedProds = new List<Product>();
    public async Task<IViewComponentResult> InvokeAsync()
    {
        if (ViewBag.selectedProds != null)
            _selectedProds = ViewBag.selectedProds;
            
        return View("ShoppingBasket", _selectedProds);
    }
}
