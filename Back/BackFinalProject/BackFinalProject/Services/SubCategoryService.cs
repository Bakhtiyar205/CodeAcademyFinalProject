using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.Utilities.Pagination;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        public async Task<SubCategory> GetSubCategoriesWithIdAsync(int subCategoryID)
        {
            return await context.SubCategories.Where(m => m.Id == subCategoryID)
                                              .Include(m=>m.Category)
                                              .Include(m=>m.Products)
                                              .FirstOrDefaultAsync();
        }

        public async Task<Paginate<SubCategory>> GetPaginateSubCategoryAsync(int? take = 9,int? page = 1)
        {
            int newPage;
            int newTake;
            if(page == null)
            {
                newPage = 1;
            }
            else
            {
                newPage = (int)page;
            }

            if (take == null)
            {
                newTake = 9;
            }
            else
            {
                newTake = (int)take;
            }

            List<SubCategory> subCategories = await context.SubCategories
                                              .Where(m => m.IsDeleted == false)
                                              .Include(m => m.Products)
                                              .Include(m => m.Category)
                                              .Skip((newPage - 1) * newTake)
                                              .Take(newTake)
                                              .ToListAsync();

            int countPages = await GetPageCount(newTake);

            Paginate<SubCategory> resultSubCategory = new(subCategories, newPage, countPages);

            return resultSubCategory;
        }

        private async Task<int> GetPageCount(int take)
        {
            return (int)Math.Ceiling((decimal)(await context.SubCategories
                            .Where(m => m.IsDeleted == false)
                            .CountAsync()) / take);
        }
    }
}
