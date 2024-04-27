using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        public override async Task<Product> Delete(int key)
        {
            Product product =await GetByKey(key);
            if (product != null)
            {
                items.Remove(product);
            }
            return product;
        }

        public override async Task<Product> GetByKey(int key)
        {
     
            Product product = items.FirstOrDefault(p => p.ProductId == key);
            if (product != null)
            {

                return product;
            }
            throw new NoProductWithGivenIdException();

        }

        public override async Task<Product> Update(Product item)
        {
            Product product =await  GetByKey(item.ProductId);
            if (product != null)
            {
                product = item;
            }
            return product;
        }

    }
}
