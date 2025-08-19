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

        public IActionResult UpdateProductPage(int id)
        {
            ViewBag.Categories = context.Categories.ToList();
            var product = context.Products.FirstOrDefault(m => m.id == id);
            return View("UpdateProduct",product);
        }

        public IActionResult UpdateProduct(Product product)
        {
            var existingProduct = context.Products.FirstOrDefault(m => m.id == product.id);
            if (existingProduct != null)
            {
                existingProduct.name = product.name;
                existingProduct.description = product.description;
                existingProduct.price = product.price;
                existingProduct.imagePath = product.imagePath;
                existingProduct.quantity = product.quantity;
                existingProduct.categoryId = product.categoryId;
                existingProduct.imagePath = product.imagePath ?? "https://via.placeholder.com/150"; // Default image path if not provided
                context.SaveChanges();
            }
            return RedirectToAction("allproducts");
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            var product = context.Products.FirstOrDefault(m => m.id == id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return RedirectToAction("allproducts");
        }
    }
}
