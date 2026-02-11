using GroceryApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(CreateProductDto dto)
        {
            _service.CreateProduct(dto);
            return Ok("Product created");
        }

    }
}
