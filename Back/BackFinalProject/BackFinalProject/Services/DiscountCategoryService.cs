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
    public class DiscountCategoryService : IDiscountCategoryService
    {
        private readonly AppDBContext context;

        public DiscountCategoryService(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<DiscountCategroy> GetDiscountCategroyAsync()
        {
            return await context.DiscountCategroies.Where(m => m.IsDeleted == false)
                                                    .Include(m => m.Category)
                                                    .ThenInclude(m => m.SubCategory)
                                                    .OrderByDescending(m => m.Id)
                                                    .FirstOrDefaultAsync();
        }

        public async Task<DiscountCategroy> GetDiscountCategroyCrudAsync()
        {
            return await context.DiscountCategroies.Where(m => m.IsDeleted == false)
                                                    .Include(m => m.Category)
                                                    .OrderByDescending(m => m.Id)
                                                    .FirstOrDefaultAsync();
        }
    }
}
