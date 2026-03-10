using System;
using System.Collections.Generic;
using ECommerceSystem.Models;
using ECommerceSystem.Payment;
using ECommerceSystem.Shipping;
using ECommerceSystem.Discounts;

namespace ECommerceSystem.Services
{
    public interface IOrderService
    {
        Order CreateOrder(ShoppingCart cart, IPaymentProcessor paymentProcessor,
                          IShippingCalculator shippingCalculator, IDiscountStrategy discount);
        List<Order> GetAllOrders();
        Order GetOrder(int orderId);
    }
}