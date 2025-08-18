using Microsoft.AspNetCore.Mvc;
using SupermarketWebApp.Data;
using SupermarketWebApp.Models;

namespace SupermarketWebApp.Controllers
{
    public class AdminController : Controller
    {
        public AppDbContext context = new AppDbContext();
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
            return RedirectToAction("AllProducts", "Products");
        }
    }
}
