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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly AppDBContext context;

        public SubCategoryService(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<List<SubCategory>> GetSubCategoriesAsync()
        {
            List<SubCategory> subCategories = await context.SubCategories.ToListAsync();
            
            return subCategories;
        }
    }
}
