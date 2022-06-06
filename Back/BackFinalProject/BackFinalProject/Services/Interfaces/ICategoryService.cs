using BackFinalProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{

    public interface ICategoryService
    {
       Task<List<Category>> GetCategoriesAsync();
       Task<Category> GetCategoriesWithIdAsync(int categoryId);
        Task<Category> GetCategoryAsNoTrackingAsync(int categoryId);
    }
}
