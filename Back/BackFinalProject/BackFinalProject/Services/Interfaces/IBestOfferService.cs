using BackFinalProject.Models;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface IBestOfferService
    {
        Task<BestOffer> GetBestOfferAsync();
    }
}
