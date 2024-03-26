using LabFourShoppingCart.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LabFourShoppingCart.Controllers
{
    public class ProductsController : Controller
    {
        private static List<ProductItem> _products = new List<ProductItem>
    {
        new ProductItem { ProductCode = "P001", Description = "Product 1", Price = 10.99m },
        new ProductItem { ProductCode = "P002", Description = "Product 2", Price = 5.49m },
        new ProductItem { ProductCode = "P003", Description = "Product 3", Price = 2.45m },
        new ProductItem { ProductCode = "P004", Description = "Product 4", Price = 1.12m },
        new ProductItem { ProductCode = "P005", Description = "Product 5", Price = 6.90m },
        new ProductItem { ProductCode = "P006", Description = "Product 6", Price = 51.98m }
    };

        private static ShoppingCart _shoppingCart = new ShoppingCart();

        public IActionResult Index()
        {
            ViewBag.CartTotal = _shoppingCart.CalculateTotalPrice();
            return View(_products);
        }

        public IActionResult AddToCart(string productCode)
        {
            var product = _products.FirstOrDefault(p => p.ProductCode == productCode);
            if (product != null)
            {
                _shoppingCart.AddItem(product);
            }
            return RedirectToAction("Index");
        }
    }
}
