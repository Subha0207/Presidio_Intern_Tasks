﻿using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartItemRepository : AbstractRepository<int, CartItem>
    {
        public override async Task<CartItem> Delete(int key)
        {
            CartItem cartItem =await GetByKey(key);
            if (cartItem != null)
            {
                items.Remove(cartItem);
            }
            return cartItem;
        }

        public override async Task<CartItem> GetByKey(int key)
        {
            CartItem cartItem = items.FirstOrDefault(p => p.ProductId == key);
            if (cartItem != null)
            {
                return cartItem;
            }
            throw new NoCartItemWithGivenIdException();
        }

        public override async Task<CartItem>Update(CartItem item)
        {
            CartItem cartItem =await GetByKey(item.ProductId);
            if (cartItem != null)
            {
                cartItem = item;
            }
            return cartItem;
        }
    }
}
