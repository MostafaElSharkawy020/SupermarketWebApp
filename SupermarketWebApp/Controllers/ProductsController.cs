using Microsoft.AspNetCore.Mvc;
using SupermarketWebApp.Data;

namespace SupermarketWebApp.Controllers
{
    public class ProductsController : Controller
    {
        public AppDbContext context = new AppDbContext();
        public IActionResult AllProducts()
        {
            ViewData["Categories"] = context.Categories.ToList();

            var allProducts = context.Products.ToList();
            return View("Products",allProducts);
        }

        public IActionResult FilterByCategory(int categoryId)
        {
            var products = context.Products.ToList();
            if (categoryId != 0 && categoryId != null)
            {
                var filteredProducts = products.Where(p => p.categoryId == categoryId).ToList();
                return PartialView("_ProductsPartialView", filteredProducts);
            }
            return PartialView("_ProductsPartialView",products);
        }
    }
}
