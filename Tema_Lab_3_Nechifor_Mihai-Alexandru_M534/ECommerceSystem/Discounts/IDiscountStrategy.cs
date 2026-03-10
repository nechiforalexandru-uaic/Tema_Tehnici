using System;

namespace ECommerceSystem.Discounts
{
    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal amount);
        string GetDiscountDescription();
    }
}
