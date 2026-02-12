using GroceryApp.Models;
using GroceryApp.Repositories;
using System.Collections.Generic;
using GroceryApp.DTOs;
using System;
namespace GroceryApp.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _repo.GetAll();
        }

        public Product CreateProduct(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock
            };
            _repo.Add(product);
            return product;
         
            }
        public void UpdateStock(UpdateStockDto dto)
        {
            var product = _repo.GetById(dto.ProductId);
            if (product == null)
               throw new Exception("Product not found");
            product.Stock = dto.Stock;
            _repo.Update(product);
        }

    }
}

