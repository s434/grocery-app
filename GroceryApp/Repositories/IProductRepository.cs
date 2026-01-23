// using System.Collections.Generic;
// using System.Threading.Tasks;
// using GroceryApp.Models;

// namespace GroceryApp.Repositories
// {
//     public interface IProductRepository
//     {
//         Task<List<Product>> GetAllAsync();
//         Task<Product> GetByIdAsync(int id);
//         Task UpdateAsync(Product product);
//     }
// }
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

