using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupermarketWebApp.Data;
using SupermarketWebApp.Models;
using SupermarketWebApp.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketWebApp.Controllers.APIs
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]

    public class ProductsController : ControllerBase
    {
        AppDbContext context = new AppDbContext();
        public IAdminRepository adminRepository = new AdminRepository();
        
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var products = context.Products.ToList();
            return Ok(products);
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Product> GetById(int id)
        {
            var products = context.Products.ToList();
            var product = products.FirstOrDefault(p => p.id == id);
            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult<Product> Create(Product product)
        {
            adminRepository.AddProduct(product);
            return CreatedAtAction(nameof(GetById), new { id = product.id }, product);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(int id, Product updatedProduct)
        {
           adminRepository.UpdateProduct(updatedProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            adminRepository.DeleteProduct(id);
            return NoContent();
        }
    }
}
