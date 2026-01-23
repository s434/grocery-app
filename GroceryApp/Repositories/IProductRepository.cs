using System.Collections.Generic;
using System.Threading.Tasks;
using GroceryApp.Models;

namespace GroceryApp.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task UpdateAsync(Product product);
    }
}
