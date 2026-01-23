// using GroceryApp.Models;
// using GroceryApp.Services;
// using Microsoft.AspNetCore.Mvc;
// using System.Collections.Generic;

// namespace GroceryApp.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class ProductsController : ControllerBase
//     {
//         private readonly IProductService _productService;

//         public ProductsController(IProductService productService)
//         {
//             _productService = productService;
//         }

//         // GET: api/products
//         [HttpGet]
//         public ActionResult<IEnumerable<Product>> GetAll()
//         {
//             return Ok(_productService.GetAllProducts());
//         }

//         // GET: api/products/5
//         [HttpGet("{id}")]
//         public ActionResult<Product> Get(int id)
//         {
//             var product = _productService.GetProductById(id);
//             if (product == null)
//                 return NotFound();

//             return Ok(product);
//         }

//         // POST: api/products
//         [HttpPost]
//         public ActionResult<Product> Create(Product product)
//         {
//             _productService.AddProduct(product);
//             return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
//         }

//         // DELETE: api/products/5
//         [HttpDelete("{id}")]
//         public IActionResult Delete(int id)
//         {
//             _productService.DeleteProduct(id);
//             return NoContent();
//         }
//         [HttpGet("test")]
//         public IActionResult Test()
//         {
//            return Ok("API is working!");
//         }

//     }
// }
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
