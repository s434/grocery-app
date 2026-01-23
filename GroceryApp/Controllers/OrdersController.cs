// using GroceryApp.Models;
// using GroceryApp.Services;
// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;

// namespace GroceryApp.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class OrdersController : ControllerBase
//     {
//         private readonly IOrderService _orderService;

//         public OrdersController(IOrderService orderService)
//         {
//             _orderService = orderService;
//         }

//         // GET: api/orders
//         [HttpGet]
//         public ActionResult<IEnumerable<Order>> GetAll()
//         {
//             return Ok(_orderService.GetAllOrders());
//         }

//         // GET: api/orders/5
//         [HttpGet("{id}")]
//         public ActionResult<Order> Get(int id)
//         {
//             var order = _orderService.GetOrderById(id);
//             if (order == null)
//                 return NotFound();

//             return Ok(order);
//         }

//         // POST: api/orders
//         [HttpPost]
//         public ActionResult<Order> Create(Order order)
//         {
//             _orderService.AddOrder(order);
//             return CreatedAtAction(nameof(Get), new { id = order.Id }, order);
//         }
//     }
// }

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
