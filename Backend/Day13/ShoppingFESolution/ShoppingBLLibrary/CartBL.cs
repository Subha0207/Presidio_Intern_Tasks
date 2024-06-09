using ShoppingBLLibrary.BLExceptions;
using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingBL
{
    public class CartBL : ICartService
    {
        readonly AbstractRepository<int, Cart> _abstractRepository;
         readonly AbstractRepository<int, Product> _productRepository;


        public CartBL(AbstractRepository<int, Cart> abstractRepository, AbstractRepository<int, Product> productRepository)
        {
            _abstractRepository = abstractRepository;
            _productRepository = productRepository;
        }

        public async Task<bool> ShippingCharges(int cartId)
        {
            var result =await  _abstractRepository.GetByKey(cartId);
            if (result != null)
            {
                double totalPrice = 0;
                if (result.CartItems.Count > 0)
                {
                    result.CartItems.ForEach(item => { totalPrice += _productRepository.GetByKey(item.ProductId).Price * item.Quantity; });

                    return totalPrice > 100;
                }
            }
            throw new NoCartWithGivenIdException();
        }

        public async Task<bool> CheckMaximumQuantity(int cartId)
        {
            var result =await _abstractRepository.GetByKey(cartId);
            if (result != null)
            {
                if (result.CartItems.Count > 0)
                {
                    foreach (var item in result.CartItems)
                    {
                        if (item.Quantity>5)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            throw new NoCartWithGivenIdException();
        }

        public async Task<Cart> CheckForDiscount(int cartId)
        {
            var result =await _abstractRepository.GetByKey(cartId);
            if (result != null)
            {
                double totalPrice = 0;
                if (result.CartItems.Count > 0)
                {
                    result.CartItems.ForEach(item => { totalPrice += _productRepository.GetByKey(item.ProductId).Price * item.Quantity; });
                    if (result.CartItems.Count == 3 && totalPrice >= 1500)
                    {
                        totalPrice -= totalPrice * 5 / 100;

                        result.TotalPrice = totalPrice;
                        return result;
                    }
                }
            }
            throw new NoCartWithGivenIdException();
        }

        public async Task<Cart> AddToCart(int cartId, CartItem item)
        {
            var cart = await _abstractRepository.GetByKey(cartId);
            if (cart != null)
            {
                
                
                if (await CheckMaximumQuantity(cartId))
                {
                    throw new QuantityExceededException();
                }

                
                cart.CartItems.Add(item);

                cart =await CheckForDiscount(cartId);

                bool shippingChargesApply = await ShippingCharges(cartId);
                if (shippingChargesApply)
                {
                    cart.TotalPrice += 100;
                }

                _abstractRepository.Update(cart);
                return cart;
            }
            throw new NoCartWithGivenIdException();
        }
    }
}
