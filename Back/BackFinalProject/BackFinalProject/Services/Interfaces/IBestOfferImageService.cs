using BackFinalProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface IBestOfferImageService
    {
        Task<List<BestOfferImages>> GetBestOfferImagesAsync();
        Task<BestOfferImages> GetOfferImageWithIdAsync(int id);
    }
}
