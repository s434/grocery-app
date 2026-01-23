using System;
using System.Threading.Tasks;
using GroceryApp.Data;
using GroceryApp.DTOs;
using GroceryApp.Models;
using GroceryApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GroceryApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        private readonly IProductRepository _productRepo;
        private readonly IOrderRepository _orderRepo;

        public OrderService(
            AppDbContext context,
            IProductRepository productRepo,
            IOrderRepository orderRepo)
        {
            _context = context;
            _productRepo = productRepo;
            _orderRepo = orderRepo;
        }

        public async Task PlaceOrderAsync(CreateOrderRequest request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var product = await _productRepo.GetByIdAsync(request.ProductId);

                if (product == null)
                    throw new Exception("Product not found");

                if (product.Stock < request.Quantity)
                    throw new Exception("Insufficient stock");

                // Reduce stock
                product.Stock -= request.Quantity;
                await _productRepo.UpdateAsync(product);

                // Create order
                var order = new Order
                {
                    ProductId = product.Id,
                    Quantity = request.Quantity,
                    TotalPrice = product.Price * request.Quantity,
                    CreatedAt = DateTime.UtcNow
                };

                await _orderRepo.AddAsync(order);

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
