using SupermarketWebApp.Models;

namespace SupermarketWebApp.Repositories
{
    public interface IAdminRepository
    {
        void AddProduct(Product product);
        void DeleteProduct(int id);
        void UpdateProduct(Product product);
    }
}
