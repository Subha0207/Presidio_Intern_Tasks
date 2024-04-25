
using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingBL
{
    public class CartBL : ICartService
    {
        readonly AbstractRepository<int, Cart> _abstractRepository;

        public CartBL(AbstractRepository<int, Cart> abstractRepository)
        {
            _abstractRepository = abstractRepository;
        }
        public bool ShippingCharges(int cartId)
        {
            var result = _abstractRepository.GetByKey(cartId);
            if (result != null)
            {
                double totalPrice = 0;
                if (result.CartItems.Count > 0)
                {
                    result.CartItems.ForEach(item => { totalPrice += item.Price; });
                    
                    return totalPrice > 100;
                }
            }
            throw new NoCartWithGivenIdException();
        }

        public Cart CheckForDiscount(int cartId)
        {
            var result = _abstractRepository.GetByKey(cartId);
            if (result != null)
            {
                double totalPrice = 0;
                if (result.CartItems.Count > 0)
                {
                    result.CartItems.ForEach(item => { totalPrice += item.Price; });
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

        public bool CheckMaximumQuantity(int cartId)
        {
            var result = _abstractRepository.GetByKey(cartId);
            if (result != null)
            {
                if (result.CartItems.Count > 0)
                {
                    foreach (var item in result.CartItems)
                    {
                        if (item.Quantity > 5)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            throw new NoCartWithGivenIdException();
        }

    }
}