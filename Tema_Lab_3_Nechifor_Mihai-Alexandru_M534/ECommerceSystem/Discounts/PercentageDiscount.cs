using System;

namespace ECommerceSystem.Discounts
{
    public class PercentageDiscount : IDiscountStrategy
    {
        private readonly decimal _percentage;

        public PercentageDiscount(decimal percentage)
        {
            _percentage = percentage;
        }

        public decimal ApplyDiscount(decimal amount)
        {
            return amount * (1 - _percentage / 100);
        }

        public string GetDiscountDescription()
        {
            return _percentage + "% discount";
        }
    }
}