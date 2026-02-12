using System.Threading.Tasks;           
using Microsoft.EntityFrameworkCore;    
using GroceryApp.Data;                
using GroceryApp.Models;    
using GroceryApp.DTOs;           
using System.Linq;        
using GroceryApp.Services;

public class DashboardService : IDashboardService
{
    private readonly AppDbContext _context;

    public DashboardService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<DashboardDto> GetDashboardAsync()
    {
        
        var totRevenue = await _context.Orders
            .SumAsync(o => o.TotalPrice); 

        var topProducts = await _context.Orders
        .GroupBy(o => o.ProductId)
        .Select(g => new
        {
            ProductId = g.Key,
            QuantitySold = g.Sum(x => x.Quantity)
        })
        .OrderByDescending(x => x.QuantitySold)
        .Take(3)
        .Join(_context.Products, x => x.ProductId, p => p.Id, (x, p) => new TopProductDto{
              Name = p.Name,
              QuantitySold = x.QuantitySold
            })
        .ToListAsync();

        var lowStock = await _context.Products
            .Where(p => p.Stock < 5)
            .Select(p => new ProductDto
            {
                Name = p.Name,
                Stock = p.Stock
            })
            .ToListAsync();

    
        return new DashboardDto
        {
            TotalRevenue = totRevenue,
            TopSellingProducts = topProducts,
            LowStockProducts = lowStock
        };
    }
}
