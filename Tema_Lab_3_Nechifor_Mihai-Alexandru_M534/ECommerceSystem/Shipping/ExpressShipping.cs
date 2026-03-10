using System;

namespace ECommerceSystem.Shipping
{
    public class ExpressShipping : IShippingCalculator
    {
        public decimal CalculateShipping(decimal orderTotal)
        {
            return 15.99m;
        }

        public string GetMethodName()
        {
            return "Express Shipping";
        }
    }
}