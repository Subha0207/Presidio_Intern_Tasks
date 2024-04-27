using ShoppingModelLibrary;
using ShoppingDALLibrary;
using ShoppingBLLibrary.BLExceptions;

namespace ShoppingBLLibrary
{
    public class ProductBL: IProductService
    {
        public ProductRepository _productRepository;

        public ProductBL(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<double> GetPriceByProductId(int productId)
        {
            var product = await _productRepository.GetByKey(productId);
            if (product != null)
            {
                return product.Price;
            }
            else
            {
                throw new ProductNotFoundException();
            }
        }
        public async Task<int> GetQuantityByProductId(int productId)
        {
            var product = await _productRepository.GetByKey(productId);
            if (product != null)
            {
                if (product.QuantityInHand == 0)
                {
                    throw new StockNotAvailableException();
                }
                return product.QuantityInHand;
            }
            else
            {
                throw new ProductNotFoundException();
            }
        }
    }
}
