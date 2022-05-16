﻿using BackFinalProject.Models;
using BackFinalProject.Utilities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductWithIdAsync(int productId);
        Task<List<Product>> GetProductWithSubCategoryIdAsync(int subcategoryId);
        Task<Paginate<Product>> GetPaginateOutletProductsAsync(int take = 1, int? page = 1);
        Task<Product> GetOutletProductWithIdAsync(int productId);
        Task<List<Product>> GetOutletProductWithSubCategoryIdAsync(int subcategoryId);
    }
}
