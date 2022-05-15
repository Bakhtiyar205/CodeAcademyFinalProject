using BackFinalProject.Models;
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
    }
}
