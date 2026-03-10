using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceSystem.Models;

namespace ECommerceSystem.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>();
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetAll()
        {
            return _products.ToList();
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }
    }
}