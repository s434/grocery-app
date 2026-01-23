using GroceryApp.Models;
using System.Collections.Generic;

namespace GroceryApp.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Update(Product product);
    }
}

