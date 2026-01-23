// using GroceryApp.Models;
// using System.Collections.Generic;

// namespace GroceryApp.Services
// {
//     public interface IProductService
//     {
//         IEnumerable<Product> GetAllProducts();
//         Product GetProductById(int id);
//         void AddProduct(Product product);
//         void DeleteProduct(int id);
//     }
// }
using GroceryApp.Models;
using System.Collections.Generic;

namespace GroceryApp.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}
