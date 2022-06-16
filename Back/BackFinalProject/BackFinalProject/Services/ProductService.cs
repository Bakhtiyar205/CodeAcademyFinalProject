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

        public async Task<Paginate<Product>> GetAllProductsAsync(int? take=9, int? page=1)
        {
            int newPage;
            int newTake;
            if (page == null)
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
            List<Product> products = await context.Products.Where(m => m.IsDeleted == false)
                                           .Include(m => m.SubCategory)
                                           .Include(m => m.ProductImages.Where(m => m.IsDeleted == false))
                                           .Skip((newPage - 1) * newTake)
                                           .Take(newTake)
                                           .ToListAsync();
            int countPages = await GetPageCount(newTake);
            Paginate<Product> resultProducts = new(products, newPage, countPages);
            return resultProducts;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await context.Products.Where(m => m.IsDeleted == false
                                             && m.IsOutlet == false)
                                            .Include(m=>m.SubCategory)
                                            .Include(m=>m.ProductImages.Where(m=>m.IsDeleted==false))
                                            .ToListAsync();
        }

        public async Task<List<Product>> GetNewOutletProductsAsync()
        {
            return await context.Products.Where(m => m.IsDeleted == false)
                                            .Include(m => m.SubCategory)
                                            .Include(m => m.ProductImages.Where(m => m.IsDeleted == false))
                                            .ToListAsync();
        }

        public async Task<Product> GetProductWithIdAsync(int productId)
        {
            return await context.Products.Where(m => m.Id == productId
                                             && m.IsDeleted == false)
                                            .Include(m => m.SubCategory)
                                            .Include(m => m.ProductImages.Where(m => m.IsDeleted == false))
                                            .FirstOrDefaultAsync();
        }

        public async Task<Product> UpdateProductWithId(int productId)
        {
            return await context.Products.Where(m => m.Id == productId
                                             && m.IsDeleted == false)
                                            .Include(m => m.SubCategory)
                                            .Include(m => m.ProductImages.Where(m => m.IsDeleted == false))
                                            .AsNoTracking()
                                            .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProductWithSubCategoryIdAsync(int subcategoryId, int productPrice = 1)
        {
            if(productPrice == 2) {
                return await context.Products.Where(m => m.SubCategoryId == subcategoryId
                                                 && m.IsDeleted == false
                                                 && m.IsOutlet == false)
                                                .OrderByDescending(m => m.RealPrice * (100 - m.Discount) / 100)
                                                .Include(m => m.SubCategory)
                                                .Include(m => m.ProductImages.Where(m => m.IsDeleted == false))
                                                .ToListAsync();
            }
            else
            {
                return await context.Products.Where(m => m.SubCategoryId == subcategoryId
                                            && m.IsDeleted == false
                                            && m.IsOutlet == false)
                                           .OrderBy(m => m.RealPrice * (100 - m.Discount) / 100)
                                           .Include(m => m.SubCategory)
                                           .Include(m => m.ProductImages.Where(m => m.IsDeleted == false))
                                           .ToListAsync();
            }
           
        }

        public async Task<List<Product>> GetProductWithSubCategoryIdDesc(int subcategoryId)
        {
            return await context.Products.Where(m => m.SubCategoryId == subcategoryId
                                             && m.IsDeleted == false
                                             && m.IsOutlet == false)
                                            .OrderByDescending(m => m.RealPrice * (100 - m.Discount) / 100)
                                            .Include(m => m.SubCategory)
                                            .Include(m => m.ProductImages.Where(m => m.IsDeleted == false))
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
            List<Product> products = await context.Products.Where(m => m.IsDeleted == false 
                                             && m.IsOutlet == true)
                                            .Include(m => m.SubCategory)
                                            .Include(m => m.ProductImages.Where(m => m.IsDeleted == false))
                                            .OrderByDescending(m => m.Date)
                                            .Skip((newPage - 1) * take)
                                            .Take(take)
                                            .ToListAsync();

            int countPages = await GetOutletPageCount(take);

            Paginate<Product> result = new(products, newPage, countPages);

            return result;

        }

        public async Task<Product> GetOutletProductWithIdAsync(int productId)
        {
            return await context.Products.Where(m => m.Id == productId 
                                            && m.IsDeleted == false 
                                            && m.IsOutlet == false)
                                            .Include(m => m.SubCategory)
                                            .Include(m => m.ProductImages.Where(m => m.IsDeleted == false))
                                            .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetOutletProductWithSubCategoryIdAsync(int subcategoryId)
        {
            return await context.Products.Where(m => m.SubCategoryId == subcategoryId 
                                             && m.IsDeleted == false 
                                             && m.IsOutlet == false)
                                            .Include(m => m.SubCategory)
                                            .Include(m => m.ProductImages.Where(m => m.IsDeleted == false))
                                            .ToListAsync();
        }

        private async Task<int> GetPageCount(int take)
        {
            return (int)Math.Ceiling((decimal)(await context.Products
                            .Where(m => m.IsDeleted == false)
                            .CountAsync()) / take);
        }

        private async Task<int> GetOutletPageCount(int take)
        {
            return (int)Math.Ceiling((decimal)(await context.Products
                            .Where(m => m.IsDeleted == false &&
                                        m.IsOutlet == true)
                            .CountAsync()) / take);
        }


    }
}
