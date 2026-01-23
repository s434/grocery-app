using GroceryApp.Models;
using GroceryApp.Repositories;
using System.Collections.Generic;

namespace GroceryApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _repo.GetAll();
        }
    }
}

