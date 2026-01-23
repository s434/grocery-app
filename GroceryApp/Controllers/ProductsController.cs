using GroceryApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroceryApp.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.GetProducts());
        }
    }
}
