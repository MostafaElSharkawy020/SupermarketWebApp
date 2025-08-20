
using SupermarketWebApp.Models;
using SupermarketWebApp.Data;

namespace SupermarketWebApp.Repositories
{

    public class AdminRepository: IAdminRepository
    {
        private readonly AppDbContext context = new AppDbContext();
        public void AddProduct(Product product)
        {
            product.imagePath = "https://via.placeholder.com/150"; // Default image path
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(int id)
        {
            var product = context.Products.FirstOrDefault(m => m.id == id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = context.Products.FirstOrDefault(m => m.id == product.id);
            if (existingProduct != null)
            {
                existingProduct.name = product.name;
                existingProduct.description = product.description;
                existingProduct.price = product.price;
                existingProduct.imagePath = product.imagePath ?? "https://via.placeholder.com/150"; // Default image path if not provided
                existingProduct.quantity = product.quantity;
                existingProduct.categoryId = product.categoryId;
                context.SaveChanges();
            }
        }
    }
}
