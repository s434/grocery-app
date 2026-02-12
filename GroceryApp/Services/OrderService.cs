using GroceryApp.Data;
using GroceryApp.Models;
using GroceryApp.Repositories;
using System;
using GroceryApp.DTOs;
using System.Collections.Generic;

namespace GroceryApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly IProductRepository _productRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly AppDbContext _context;

        public OrderService(IProductRepository productRepo, IOrderRepository orderRepo, AppDbContext context)
        {
            _productRepo = productRepo;
            _orderRepo = orderRepo;
            _context = context;
        }
        public IEnumerable<Order> GetOrders()
        {
            return _orderRepo.GetAll();
        }

        public Order CreateOrder(CreateOrderDto dto)
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                var product = _productRepo.GetById(dto.ProductId);

                if (product == null)
                    throw new Exception("Product not found");

                if (product.Stock < dto.Quantity)
                    throw new Exception("Insufficient stock");

                product.Stock -= dto.Quantity;
                _productRepo.Update(product);

                var order = new Order
                {
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity,
                    TotalPrice = product.Price * dto.Quantity,
                    CreatedAt = DateTime.UtcNow
                };

                _orderRepo.Add(order);

                _context.SaveChanges();
                transaction.Commit();

                return order;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
