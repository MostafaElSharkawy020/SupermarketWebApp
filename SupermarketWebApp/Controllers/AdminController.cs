using Microsoft.AspNetCore.Mvc;
using SupermarketWebApp.Data;
using SupermarketWebApp.Models;

namespace SupermarketWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext context = new AppDbContext();
        public IActionResult NewProductPage()
        {
            ViewBag.Categories = context.Categories.ToList();
            return View("NewProduct");
        }

        public IActionResult AddProduct(Product product)
        {
            product.imagePath = "https://via.placeholder.com/150"; // Default image path
            context.Products.Add(product);
            context.SaveChanges();
            return View("AllProductsAdmin",context.Products.ToList());
        }

        public IActionResult AllProducts()
        {
            ViewBag.Categories = context.Categories.ToList();
            var products = context.Products.ToList();
            return View("AllProductsAdmin",products);
        }
    }
}
