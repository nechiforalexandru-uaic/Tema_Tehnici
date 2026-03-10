using System;

namespace ECommerceSystem.Shipping
{
    public class StandardShipping : IShippingCalculator
    {
        public decimal CalculateShipping(decimal orderTotal)
        {
            if (orderTotal < 50)
                return 5.99m;
            else
                return 0;
        }

        public string GetMethodName()
        {
            return "Standard Shipping";
        }
    }
}