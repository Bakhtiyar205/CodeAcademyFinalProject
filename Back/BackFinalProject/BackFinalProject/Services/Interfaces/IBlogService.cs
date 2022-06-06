using BackFinalProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface IBlogService
    {
        Task<List<Blog>> GetBlogsAsync();
        Task<Blog> GetBlogAsync(int blogId);
        Task<List<Blog>> GetBlogWithCategoryAsync(int categoryId);
    }
}
