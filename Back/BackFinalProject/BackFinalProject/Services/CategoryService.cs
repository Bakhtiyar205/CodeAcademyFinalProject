using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly AppDBContext _context;

        public CategoryService(AppDBContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            List<Category> categories = await _context.Categories
                                            .Where(m=>m.İsDeleted ==false)
                                            .Include(m=>m.Blogs.Where(m => !m.IsDeleted))
                                            .Include(m=>m.SubCategory.Where(m=>!m.IsDeleted))
                                            .Include(m=>m.DiscountCategroies)
                                            .ToListAsync();
            return categories;
        }

        public async Task<Category> GetCategoriesWithIdAsync(int categoryId)
        {
            return await _context.Categories.Where(m => m.Id == categoryId)
                                            .Include(m => m.Blogs.Where(m => !m.IsDeleted))
                                            .Include(m => m.SubCategory.Where(m => !m.IsDeleted))
                                            .Include(m => m.DiscountCategroies)
                                            .FirstOrDefaultAsync();
        }

        public async Task<Category> GetCategoryAsNoTrackingAsync(int categoryId)
        {
            return await _context.Categories
                        .Include(m => m.Blogs.Where(m => !m.IsDeleted))
                        .Include(m => m.SubCategory.Where(m => !m.IsDeleted))
                        .Include(m => m.DiscountCategroies)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(m => m.Id == categoryId);
        }
    }
}
