using Microsoft.EntityFrameworkCore;
using ProductsAPI.Context;
using ProductsAPI.Interfaces;
using ProductsAPI.Models;

namespace ProductsAPI.Repository
{
    public class ProductRepository :IRepository<int,Product>
    {
        private readonly ProductContext _context;
        public ProductRepository(ProductContext context)
        {
            _context = context;
        }

        public async Task<Product> Get(int productID)
        {
            var product = await _context.Products.FirstOrDefaultAsync(e => e.Id == productID);
            return product;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            var products = await _context.Products.ToListAsync();
            return products;

        }
    }
}
