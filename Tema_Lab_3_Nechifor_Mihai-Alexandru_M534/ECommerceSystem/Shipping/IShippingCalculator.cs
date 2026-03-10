using System;

namespace ECommerceSystem.Shipping
{
    public interface IShippingCalculator
    {
        decimal CalculateShipping(decimal orderTotal);
        string GetMethodName();
    }
}