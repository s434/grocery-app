using GroceryApp.Models;
using System.Collections.Generic;

namespace GroceryApp.Repositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        IEnumerable<Order> GetAll();

    }
}
