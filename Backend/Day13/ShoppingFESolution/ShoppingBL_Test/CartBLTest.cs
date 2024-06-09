using NUnit.Framework;
using ShoppingBL;
using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System.Collections.Generic;

namespace ShoppingBLTest
{
    public class Tests
    {
        AbstractRepository<int, Cart> _cartRepository;
        ICartService _cartService;
        AbstractRepository<int, Product> productRepository;

        [SetUp]
        public void Setup()
        {
            _cartRepository = new CartRepository();
            productRepository = new ProductRepository();
            _cartService = new CartBL(_cartRepository,productRepository);
        }

        [Test]
        public async Task ShippingCharges_Pass_Test()
        {
            // Arrange
            var product = new Product { ProductId = 1, Image = "", Name = "Bag", Price = 400, QuantityInHand = 3 };
            productRepository.Add(product);
            List<CartItem> cartItems = new List<CartItem>();
            
            CartItem cartItem1 = new CartItem() { CartId = 1, Discount = 0, Price = 400, Product = product, ProductId = 1, Quantity = 3 };
            cartItems.Add(cartItem1);
            var cart = new Cart {
                CartId = 1,
                CartItems =cartItems
            };
            _cartRepository.Add(cart);
            _cartService = new CartBL(_cartRepository, productRepository);
            
            // Act
            var result =await _cartService.ShippingCharges(cart.CartId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        
        public async Task ShippingCharges_Fail_Test()
        {
            // Arrange
            var product = new Product { ProductId = 2, Image = "", Name = "Shoe", Price = 99, QuantityInHand = 1 };
            productRepository.Add(product);
            List<CartItem> cartItems = new List<CartItem>();

            CartItem cartItem1 = new CartItem() { CartId = 2, Discount = 0, Price = 99, Product = product, ProductId = 2, Quantity = 1 };
            cartItems.Add(cartItem1);
            var cart = new Cart
            {
                CartId = 2,
                CartItems = cartItems
            };
            _cartRepository.Add(cart);
            _cartService = new CartBL(_cartRepository, productRepository);

            // Act
            var result = await _cartService.ShippingCharges(cart.CartId);

            // Assert
            Assert.IsFalse(result);
        }
        [Test]
         public  async Task ShippingCharges_NoCartWithGivenIdException_Test()
          {
           // Arrange
           int nonExistentCartId = 999; // This ID should not exist in the repository
           _cartService = new CartBL(_cartRepository, productRepository);

           // Act & Assert
           Assert.ThrowsAsync<NoCartWithGivenIdException>(() => _cartService.ShippingCharges(nonExistentCartId));
           }


        [Test]
        public async Task CheckForDiscount_Pass_Test()
        {
            
            // Arrange
            var product1 = new Product { ProductId = 1, Image = "", Name = "Shoe", Price = 500, QuantityInHand = 1 };
            productRepository.Add(product1);
            var product2= new Product { ProductId = 2, Image = "", Name = "Socks", Price = 500, QuantityInHand = 1 };
            productRepository.Add(product2);
            var product3 = new Product { ProductId = 3, Image = "", Name = "Snack", Price = 509, QuantityInHand = 1 };
            productRepository.Add(product3);
            List<CartItem> cartItems = new List<CartItem>();

            CartItem cartItem1 = new CartItem() { CartId = 2,  Product = product1, ProductId = 1, Quantity = 1 };
            cartItems.Add(cartItem1);
            CartItem cartItem2= new CartItem() { CartId = 2,  Product = product2, ProductId = 3, Quantity = 1 };
            cartItems.Add(cartItem2);

            CartItem cartItem3 = new CartItem() { CartId = 2, Product = product3, ProductId = 3, Quantity = 1 };
            cartItems.Add(cartItem3);
            var cart = new Cart
            {
                CartId = 2,
                CartItems = cartItems
            };
          await  _cartRepository.Add(cart);
            _cartService = new CartBL(_cartRepository, productRepository);


            // Act
            var result = await _cartService.CheckForDiscount(cart.CartId);

            // Assert
            Assert.AreEqual(1425, result.TotalPrice);
            
        }
        [Test]
        public async Task CheckForDiscount_Fail_Test()
        {
            // Arrange
            var cart = new Cart { CartId = 1, CartItems = new List<CartItem> { new CartItem { Price = 400 }, new CartItem { Price = 400 }, new CartItem { Price = 400 } } };
            _cartRepository.Add(cart);

            // Act & Assert
            Assert.Throws<NoCartWithGivenIdException>(() => _cartService.CheckForDiscount(9999)); // Use a CartId that does not exist
        }


        [Test]
        public async Task CheckMaximumQuantity_Pass_Test()
        {
            // Arrange
            var cart = new Cart { CartItems = new List<CartItem> { new CartItem { Quantity = 6 } } };
            _cartRepository.Add(cart);

            // Act
            var result =await _cartService.CheckMaximumQuantity(cart.CartId);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public async Task CheckMaximumQuantity_Fail_Test()
        {
            // Arrange
            var cart = new Cart { CartItems = new List<CartItem> { new CartItem { Quantity = 5 } } };
            _cartRepository.Add(cart);

            // Act
            var result = await _cartService.CheckMaximumQuantity(cart.CartId);

            // Assert
            Assert.IsFalse(result);
        }
    }
}