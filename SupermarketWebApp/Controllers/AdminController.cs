using Microsoft.AspNetCore.Mvc;
using SupermarketWebApp.Data;
using SupermarketWebApp.Models;
using SupermarketWebApp.Repositories;

namespace SupermarketWebApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext context = new AppDbContext();
        private readonly IAdminRepository adminRepository = new AdminRepository();
        public IActionResult NewProductPage()
        {
            ViewBag.Categories = context.Categories.ToList();
            return View("NewProduct");
        }

        public IActionResult AddProduct(Product product)
        {
            adminRepository.AddProduct(product);
            return RedirectToAction("allproducts");
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
            adminRepository.UpdateProduct(product);
            return RedirectToAction("allproducts");
        }

        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            adminRepository.DeleteProduct(id);
            return RedirectToAction("allproducts");
        }
    }
}
