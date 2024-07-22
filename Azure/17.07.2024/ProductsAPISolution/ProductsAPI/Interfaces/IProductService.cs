using ProductsAPI.Models;

namespace ProductsAPI.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<Product> GetProductByID(int id);

    }
}
