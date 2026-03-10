using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceSystem.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; }

        public ShoppingCart()
        {
            Items = new List<CartItem>();
        }

        public decimal Total
        {
            get { return Items.Sum(i => i.Subtotal); }
        }
    }
}