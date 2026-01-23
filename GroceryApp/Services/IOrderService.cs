// using GroceryApp.Models;
// using System.Collections.Generic;

// namespace GroceryApp.Services
// {
//     public interface IOrderService
//     {
//         IEnumerable<Order> GetAllOrders();
//         Order GetOrderById(int id);
//         void AddOrder(Order order);
//     }
// }

using GroceryApp.Models;

namespace GroceryApp.Services
{
    public interface IOrderService
    {
        Order CreateOrder(CreateOrderDto dto);
    }
}
