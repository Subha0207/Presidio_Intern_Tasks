using ProductsAPI.Exceptions;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;

namespace ProductsAPI
{
    public class ProductService : IProductService
    {

        private readonly IRepository<int, Product> _repository;

        public ProductService(IRepository<int, Product> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _repository.Get();
            if (products.Count() == 0)
                throw new NoProductFoundException();
            return products;
        }

        public async Task<Product> GetProductByID(int id)
        {
            var product = await _repository.Get(id);
            if (product != null)
            {
                return product;
            }
            throw new NoProductFoundException();
        }
    }
}