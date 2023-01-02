using E_Commerce_Project.Data.ViewModels;
using E_Commerce_Project.Models.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Project.Data
{
    public class ShoppingBasketSummary
    {
        public static ShoppingBasketSummary _shoppingBasketSummary;
        public AppDbContext _context { get; set; }

        public string ShoppingBasketId { get; set; }

        public List<ShoppingBasketItem> shoppingBasketItems { get; set; }

        public ShoppingBasketSummary(AppDbContext context)
        {
            _context = context;
        }
        public ShoppingBasketSummary() { }

        public static void populateShoppingBasketSummary(ShoppingBasketSummary shoppingBasketSummary)
        {
            _shoppingBasketSummary = shoppingBasketSummary;
        }

        public static ShoppingBasketSummary getShoppingBasketSummary()
        {
            return _shoppingBasketSummary;
        }

        public decimal GetShoppingBasketTotal() =>  shoppingBasketItems.Sum(si => si.subTotal);
    }
}
