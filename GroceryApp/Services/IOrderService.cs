using System.Threading.Tasks;
using GroceryApp.DTOs;

namespace GroceryApp.Services
{
    public interface IOrderService
    {
        Task PlaceOrderAsync(CreateOrderRequest request);
    }
}
