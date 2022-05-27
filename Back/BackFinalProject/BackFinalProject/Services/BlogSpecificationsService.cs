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
    public class BlogSpecificationsService : IBlogSpecificationService
    {
        private readonly AppDBContext context;

        public BlogSpecificationsService(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<BlogSpesification> GetBlogSpecificationAsync(int blogSpecificationId)
        {
            return await context.BlogSpesifications.Where(m => m.Id == blogSpecificationId && !m.IsDeleted).FirstOrDefaultAsync();
        }
    }
}
