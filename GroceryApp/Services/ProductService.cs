// using GroceryApp.Data;
// using GroceryApp.Models;
// using System.Collections.Generic;
// using System.Linq;

// namespace GroceryApp.Services
// {
//     public class ProductService : IProductService
//     {
//         private readonly AppDbContext _context;

//         public ProductService(AppDbContext context)
//         {
//             _context = context;
//         }

//         public IEnumerable<Product> GetAllProducts()
//         {
//             return _context.Products.ToList();
//         }

//         public Product GetProductById(int id)
//         {
//             return _context.Products.Find(id);
//         }

//         public void AddProduct(Product product)
//         {
//             _context.Products.Add(product);
//             _context.SaveChanges();
//         }

//         public void DeleteProduct(int id)
//         {
//             var product = _context.Products.Find(id);
//             if (product != null)
//             {
//                 _context.Products.Remove(product);
//                 _context.SaveChanges();
//             }
//         }
//     }
// }
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

