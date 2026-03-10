using System;
using ECommerceSystem.Models;

namespace ECommerceSystem.Services
{
    public interface IShoppingCartService
    {
        void AddItem(Product product, int quantity);
        void RemoveItem(int productId);
        ShoppingCart GetCart();
        void ClearCart();
    }
}