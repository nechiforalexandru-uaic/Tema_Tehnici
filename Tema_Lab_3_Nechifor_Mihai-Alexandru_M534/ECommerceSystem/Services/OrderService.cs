using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceSystem.Models;
using ECommerceSystem.Payment;
using ECommerceSystem.Shipping;
using ECommerceSystem.Discounts;

namespace ECommerceSystem.Services
{
    public class OrderService : IOrderService
    {
        private List<Order> _orders;

        public OrderService()
        {
            _orders = new List<Order>();
        }

        public Order CreateOrder(ShoppingCart cart, IPaymentProcessor paymentProcessor,
                                IShippingCalculator shippingCalculator, IDiscountStrategy discount)
        {
            decimal shippingCost = shippingCalculator.CalculateShipping(cart.Total);
            decimal discountedTotal = discount.ApplyDiscount(cart.Total);
            bool paymentSuccess = paymentProcessor.ProcessPayment(discountedTotal + shippingCost);

            var order = new Order(cart.Items.ToList(), discountedTotal + shippingCost,
                                  shippingCalculator.GetMethodName());

            if (paymentSuccess)
            {
                order.PaymentStatus = "Paid";
                order.Status = "Confirmed";
            }

            _orders.Add(order);
            return order;
        }

        public List<Order> GetAllOrders()
        {
            return _orders.ToList();
        }

        public Order GetOrder(int orderId)
        {
            return _orders.FirstOrDefault(o => o.Id == orderId);
        }
    }
}