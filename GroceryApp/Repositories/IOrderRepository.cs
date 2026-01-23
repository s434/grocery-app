using System.Threading.Tasks;
using GroceryApp.Models;

namespace GroceryApp.Repositories
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
    }
}
