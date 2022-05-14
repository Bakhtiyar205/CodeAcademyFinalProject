using BackFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface IGiftCardService
    {
        Task<List<GiftCard>> GiftCardsAsync();
        Task<GiftCard> GiftCarWithIddAsync(int giftCardId);
    }
}
