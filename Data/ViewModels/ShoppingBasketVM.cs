using E_Commerce_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce_Project.Data.ViewModels
{
    public class ShoppingBasketVM
    {
        public ShoppingBasketSummary shoppingBasketSummary { get; set; }
        public decimal totalPrice { get; set; }
    }
}
