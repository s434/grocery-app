using GroceryApp.Models;
using System.Collections.Generic;

namespace GroceryApp.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product CreateProduct(CreateProductDto dto);
    }
}
