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
    public class ProductService : IProductService
    {
        private readonly AppDBContext context;

        public ProductService(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await context.Products.Where(m => m.IsDeleted == false)
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
            return await context.Products.Where(m=>m.SubCategoryId == subcategoryId && m.IsDeleted == false)
                                            .Include(m => m.SubCategory)
                                            .Include(m => m.ProductImages)
                                            .ToListAsync();
        }

    }
}
