using OnlineShop.Models;

namespace OnlineShop.Services
{
    public class ProductService : IProductService
    {
        private readonly ProjectTestContext _context;
        public ProductService()
        {
            _context = new ProjectTestContext();
        }
        public void AddProduct(Product product)
        {
            using(var context = _context)
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void DeleteById(int id)
        {
            using(var context = _context)
            {
                var product = context.Products.FirstOrDefault(p => p.Id == id);
                if(product == null)
                {
                    throw new Exception("That item is not found");
                }
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        public Product GetProductByID(int id)
        {
            using (var context = _context)
            {
                var product = context.Products.FirstOrDefault(p=>p.Id == id);
                if(product== null)
                {
                    throw new Exception("That item is not found");
                }
                return product;
            }
        }

        public IEnumerable<Product> GetProducts()
        {
            using(var context = _context)
            {
                return context.Products;
            }
        }
    }
}
