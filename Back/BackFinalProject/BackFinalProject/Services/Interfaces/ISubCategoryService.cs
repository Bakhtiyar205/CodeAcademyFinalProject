using BackFinalProject.Models;
using BackFinalProject.Utilities.Pagination;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface ISubCategoryService
    {
        Task<List<SubCategory>> GetSubCategoriesAsync();
        Task<SubCategory> GetSubCategoriesWithIdAsync(int subCategoryID);
        Task<Paginate<SubCategory>> GetPaginateSubCategoryAsync(int? take = 9, int? page = 1);


    }
}
