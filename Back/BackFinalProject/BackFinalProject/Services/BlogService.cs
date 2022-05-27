using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Services
{
    public class BlogService : IBlogService
    {
        private readonly AppDBContext context;

        public BlogService(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<List<Blog>> GetBlogsAsync()
        {
            return await context.Blogs.Where(m => m.IsDeleted == false)
                                        .Include(m=>m.BlogSpesifications)
                                        .ToListAsync();
        }

        public async Task<Blog> GetBlogAsync(int blogId)
        {
            return await context.Blogs.Where(m => m.Id == blogId && m.IsDeleted == false)
                                        .Include(m => m.BlogSpesifications)
                                        .Include(m=>m.Category)
                                        .FirstOrDefaultAsync();
        }

        public async Task<List<Blog>> GetBlogWithCategoryAsync(int categoryId)
        {
            return await context.Blogs.Where(m => m.CategoryId == categoryId && m.IsDeleted == false)
                                        .Include(m => m.BlogSpesifications)
                                        .Include(m => m.Category)
                                        .ToListAsync();
        }
    }
}
