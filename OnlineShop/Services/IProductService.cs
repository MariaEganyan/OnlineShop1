using OnlineShop.Models;

namespace OnlineShop.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product GetProductByID(int id);
        void AddProduct(Product product);
        void DeleteById(int id);
    }
}
