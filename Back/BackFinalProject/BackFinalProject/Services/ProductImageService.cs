using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackFinalProject.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly AppDBContext context;

        public ProductImageService(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<ProductImage> ProductImageWithIdAsync(int id)
        {
            return await context.ProductImages.FirstOrDefaultAsync(m=>m.Id == id && m.IsDeleted == false);
        }


    }
}
