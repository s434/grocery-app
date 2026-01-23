using GroceryApp.Data;
using GroceryApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace GroceryApp.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Product> GetAll() => _context.Products.ToList();

        public Product GetById(int id) => _context.Products.Find(id);

        public void Update(Product product)
        {
            _context.Products.Update(product);
        }
    }
}
