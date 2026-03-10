using System;

namespace ECommerceSystem.Payment
{
    public class PayPalProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of ${amount:F2}...");
            return true;
        }

        public string GetPaymentMethod()
        {
            return "PayPal";
        }
    }
}