using System;

namespace ECommerceSystem.Payment
{
    public class CreditCardProcessor : IPaymentProcessor
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of ${amount:F2}...");
            return true;
        }

        public string GetPaymentMethod()
        {
            return "Credit Card";
        }
    }
}