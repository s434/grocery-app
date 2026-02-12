using System.Threading.Tasks;
using GroceryApp.Models; 
using GroceryApp.DTOs;

namespace GroceryApp.Services
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardAsync();
    }
}
