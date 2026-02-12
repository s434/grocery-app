using GroceryApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using GroceryApp.DTOs;

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
           var product =  _service.CreateProduct(dto);
            return Ok(new { message = "Product created", productId = product.Id });
        }

    }
}
