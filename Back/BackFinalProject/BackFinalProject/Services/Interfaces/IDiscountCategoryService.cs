using BackFinalProject.Models;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface IDiscountCategoryService
    {
        Task<DiscountCategroy> GetDiscountCategroyAsync();
        Task<DiscountCategroy> GetDiscountCategroyCrudAsync();
    }
}
