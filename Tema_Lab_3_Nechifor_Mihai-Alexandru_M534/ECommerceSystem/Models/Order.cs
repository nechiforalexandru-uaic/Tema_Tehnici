using System;
using System.Collections.Generic;

namespace ECommerceSystem.Models
{
    public class Order
    {
        private static int _nextId = 1;

        public int Id { get; private set; }
        public List<CartItem> Items { get; private set; }
        public decimal TotalAmount { get; private set; }
        public DateTime OrderDate { get; private set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }
        public string ShippingMethod { get; set; }

        public Order(List<CartItem> items, decimal totalAmount, string shippingMethod)
        {
            Id = _nextId++;
            Items = items;
            TotalAmount = totalAmount;
            OrderDate = DateTime.Now;
            Status = "Pending";
            PaymentStatus = "Pending";
            ShippingMethod = shippingMethod;
        }
    }
}