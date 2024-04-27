using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICartService
    {
        
        public Task<bool> CheckMaximumQuantity(int cartId);
        public Task<Cart> CheckForDiscount(int cartId);
        public Task<bool> ShippingCharges(int cartId);
        public Task<Cart> AddToCart(int cartId, CartItem item);

    }
}
