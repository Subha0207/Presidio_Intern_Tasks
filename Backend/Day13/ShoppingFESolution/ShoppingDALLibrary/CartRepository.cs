using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        public override async Task< Cart> Delete(int key)
        {
            Cart cart = await GetByKey(key);
            if (cart != null)
            {
                items.Remove(cart);
            }
            return cart;
        }

        public override async Task<Cart> GetByKey(int key)
        {
            Cart cart = items.FirstOrDefault(c => c.CartId == key);
            if (cart != null)
            {
                return cart;
            }
            throw new NoCartWithGivenIdException();
        }

        public override async Task<Cart> Update(Cart item)
        {
            int index = items.FindIndex(c => c.CartId == item.CartId);
            if (index != -1)
            {
                items[index] = item;
                return items[index];
            }
            throw new NoCartWithGivenIdException();
        }

    }
}
