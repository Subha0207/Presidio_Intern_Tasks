using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public interface IProductService
    {
        public  Task<double> GetPriceByProductId(int productId);
        public Task<int> GetQuantityByProductId(int productId);
    }
}
