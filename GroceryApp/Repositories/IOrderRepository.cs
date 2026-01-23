using GroceryApp.Models;

namespace GroceryApp.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
    }
}
