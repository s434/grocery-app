using System.Threading.Tasks;
using GroceryApp.Models; 

namespace GroceryApp.Services
{
    public interface IDashboardService
    {
        Task<DashboardDto> GetDashboardAsync();
    }
}
