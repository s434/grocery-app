using GroceryApp.Models;
using GroceryApp.DTOs;
using System.Collections.Generic;

namespace GroceryApp.Services
{
    public interface IOrderService
    {   IEnumerable<Order> GetOrders();
        Order CreateOrder(CreateOrderDto dto);
    }
}
