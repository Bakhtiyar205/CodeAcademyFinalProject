using BackFinalProject.Models;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface IProductImageService
    {
        Task<ProductImage> ProductImageWithIdAsync(int id);
    }
}
