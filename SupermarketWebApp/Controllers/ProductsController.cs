using Microsoft.AspNetCore.Mvc;
using SupermarketWebApp.Data;

namespace SupermarketWebApp.Controllers
{
    public class ProductsController : Controller
    {
        public AppDbContext context = new AppDbContext();
        public IActionResult AllProducts()
        {
            
            var allProducts = context.Products.ToList();
            return View("Products",allProducts);
        }
    }
}
