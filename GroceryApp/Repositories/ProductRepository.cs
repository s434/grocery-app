// using System.Collections.Generic;
// using System.Threading.Tasks;
// using Microsoft.EntityFrameworkCore;
// using GroceryApp.Data;
// using GroceryApp.Models;

// namespace GroceryApp.Repositories
// {
//     public class ProductRepository : IProductRepository
//     {
//         private readonly AppDbContext _context;

//         public ProductRepository(AppDbContext context)
//         {
//             _context = context;
//         }

//         public async Task<List<Product>> GetAllAsync()
//         {
//             return await _context.Products.ToListAsync();
//         }

//         public async Task<Product> GetByIdAsync(int id)
//         {
//             return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
//         }

//         public async Task UpdateAsync(Product product)
//         {
//             _context.Products.Update(product);
//             await _context.SaveChangesAsync();
//         }
//     }
// }

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
