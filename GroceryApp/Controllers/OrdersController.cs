using GroceryApp.Models;
using GroceryApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroceryApp.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Create(CreateOrderDto dto)
        {
            try
            {
                var order = _service.CreateOrder(dto);
                return Ok(order);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
