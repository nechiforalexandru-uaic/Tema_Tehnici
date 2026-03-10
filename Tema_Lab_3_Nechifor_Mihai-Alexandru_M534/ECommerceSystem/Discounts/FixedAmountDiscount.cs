using System;

namespace ECommerceSystem.Discounts
{
    public class FixedAmountDiscount : IDiscountStrategy
    {
        private readonly decimal _amount;

        public FixedAmountDiscount(decimal amount)
        {
            _amount = amount;
        }

        public decimal ApplyDiscount(decimal amount)
        {
            if (amount - _amount < 0)
                return 0;
            else
                return amount - _amount;
        }

        public string GetDiscountDescription()
        {
            return "$" + _amount + " off";
        }
    }
}