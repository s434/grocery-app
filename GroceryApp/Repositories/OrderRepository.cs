using GroceryApp.Data;
using GroceryApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace GroceryApp.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;

        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }
        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

    }
}
