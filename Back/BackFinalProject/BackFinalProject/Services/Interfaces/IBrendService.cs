using BackFinalProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface IBrendService
    {
        Task<Brend> GetBrendWithIdAsync(int brendId);
        Task<List<Brend>> GetBrendsAsync();
    }
}
