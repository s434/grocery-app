using GroceryApp.Models;
using GroceryApp.DTOs;

namespace GroceryApp.Services
{
    public interface IOrderService
    {
        Order CreateOrder(CreateOrderDto dto);
    }
}
