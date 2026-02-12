using System.Collections.Generic;

public class DashboardDto
{
    public decimal TotalRevenue { get; set; }
    public List<TopProductDto> TopSellingProducts { get; set; }
    public List<ProductDto> LowStockProducts { get; set; }
}