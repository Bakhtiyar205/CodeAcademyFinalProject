using BackFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface IBestOfferService
    {
        Task<BestOffer> GetBestOfferAsync();
    }
}
