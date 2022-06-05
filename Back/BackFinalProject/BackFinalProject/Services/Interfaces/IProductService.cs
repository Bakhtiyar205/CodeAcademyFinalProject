using BackFinalProject.Models;
using BackFinalProject.Utilities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface IProductService
    {
        Task<Paginate<Product>> GetAllProductsAsync(int? take = 9, int? page = 1);
        Task<Product> UpdateProductWithId(int productId);
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductWithIdAsync(int productId);
        Task<List<Product>> GetProductWithSubCategoryIdAsync(int subcategoryId, int productPrice = 1);
        Task<Paginate<Product>> GetPaginateOutletProductsAsync(int take = 1, int? page = 1);
        Task<Product> GetOutletProductWithIdAsync(int productId);
        Task<List<Product>> GetOutletProductWithSubCategoryIdAsync(int subcategoryId);
        Task<List<Product>> GetNewOutletProductsAsync();

    }
}
