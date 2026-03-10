using System;

namespace ECommerceSystem.Models
{
    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal
        {
            get { return Product.Price * Quantity; }
        }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}