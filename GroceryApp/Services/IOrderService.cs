using GroceryApp.Models;

namespace GroceryApp.Services
{
    public interface IOrderService
    {
        Order CreateOrder(CreateOrderDto dto);
    }
}
