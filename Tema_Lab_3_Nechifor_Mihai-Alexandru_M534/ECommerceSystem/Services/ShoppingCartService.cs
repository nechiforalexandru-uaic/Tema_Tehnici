using System;
using System.Linq;
using ECommerceSystem.Models;

namespace ECommerceSystem.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private ShoppingCart _cart;

        public ShoppingCartService()
        {
            _cart = new ShoppingCart();
        }

        public void AddItem(Product product, int quantity)
        {
            var existingItem = _cart.Items.FirstOrDefault(i => i.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _cart.Items.Add(new CartItem(product, quantity));
            }
        }

        public void RemoveItem(int productId)
        {
            var item = _cart.Items.FirstOrDefault(i => i.Product.Id == productId);
            if (item != null)
            {
                _cart.Items.Remove(item);
            }
        }

        public ShoppingCart GetCart()
        {
            return _cart;
        }

        public void ClearCart()
        {
            _cart = new ShoppingCart();
        }
    }
}