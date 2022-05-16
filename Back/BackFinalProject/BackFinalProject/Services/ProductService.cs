using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.Utilities.Pagination;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDBContext context;

        public ProductService(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await context.Products.Where(m => m.IsDeleted == false && m.IsOutlet == false)
                                            .Include(m=>m.SubCategory)
                                            .Include(m=>m.ProductImages)
                                            .ToListAsync();
        }

        public async Task<Product> GetProductWithIdAsync(int productId)
        {
            return await context.Products.Where(m => m.Id == productId && m.IsDeleted == false)
                                            .Include(m => m.SubCategory)
                                            .Include(m => m.ProductImages)
                                            .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProductWithSubCategoryIdAsync(int subcategoryId)
        {
            return await context.Products.Where(m=>m.SubCategoryId == subcategoryId && m.IsDeleted == false && m.IsOutlet == false)
                                            .Include(m => m.SubCategory)
                                            .Include(m => m.ProductImages)
                                            .ToListAsync();
        }

        public async Task<Paginate<Product>> GetPaginateOutletProductsAsync(int take = 1, int? page = 1)
        {
            int newPage;
            if(page == null)
            {
                newPage = 1;
            }
            else
            {
                newPage = (int)page;
            }
            List<Product> products = await context.Products.Where(m => m.IsDeleted == false && m.IsOutlet == true)
                                            .Include(m => m.SubCategory)
                                            .Include(m => m.ProductImages)
                                            .OrderByDescending(m => m.Date)
                                            .Skip((newPage - 1) * take)
                                            .Take(take)
                                            .ToListAsync();

            int countPages = await GetPageCount(take);

            Paginate<Product> result = new(products, newPage, countPages);

            return result;

        }

        public async Task<Product> GetOutletProductWithIdAsync(int productId)
        {
            return await context.Products.Where(m => m.Id == productId && m.IsDeleted == false && m.IsOutlet == false)
                                            .Include(m => m.SubCategory)
                                            .Include(m => m.ProductImages)
                                            .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetOutletProductWithSubCategoryIdAsync(int subcategoryId)
        {
            return await context.Products.Where(m => m.SubCategoryId == subcategoryId && m.IsDeleted == false && m.IsOutlet == false)
                                            .Include(m => m.SubCategory)
                                            .Include(m => m.ProductImages)
                                            .ToListAsync();
        }

        private async Task<int> GetPageCount(int take)
        {
            return (int)Math.Ceiling((decimal)(await context.Products
                            .Where(m => m.IsDeleted == false && m.IsOutlet == true)
                            .CountAsync()) / take);
        }


    }
}
