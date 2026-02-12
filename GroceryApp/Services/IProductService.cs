using GroceryApp.Models;
using System.Collections.Generic;
using GroceryApp.DTOs;

namespace GroceryApp.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
        Product CreateProduct(CreateProductDto dto);
        void UpdateStock(UpdateStockDto dto);

    }
}
