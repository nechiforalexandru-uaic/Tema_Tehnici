using System;

namespace ECommerceSystem.Payment
{
    public interface IPaymentProcessor
    {
        bool ProcessPayment(decimal amount);
        string GetPaymentMethod();
    }
}