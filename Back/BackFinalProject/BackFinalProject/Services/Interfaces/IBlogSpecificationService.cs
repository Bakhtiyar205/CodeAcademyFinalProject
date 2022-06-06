using BackFinalProject.Models;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface IBlogSpecificationService
    {
        Task<BlogSpesification> GetBlogSpecificationAsync(int blogSpecificationId);
    }
}
