using System;
using System.Collections.Generic;
using ECommerceSystem.Models;

namespace ECommerceSystem.Repositories
{
    public interface IProductRepository
    {
        Product GetById(int id);
        List<Product> GetAll();
        void Add(Product product);
    }
}