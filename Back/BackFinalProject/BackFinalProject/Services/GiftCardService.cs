using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Services
{
    public class GiftCardService : IGiftCardService
    {
        private readonly AppDBContext context;

        public GiftCardService(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<List<GiftCard>> GiftCardsAsync()
        {
            return await context.GiftCards.Where(m => m.IsDeleted == false)
                                           .ToListAsync();
        }

        public async Task<GiftCard> GiftCarWithIddAsync(int giftCardId)
        {
            return await context.GiftCards.Where(m => m.IsDeleted == false && m.Id == giftCardId)
                                           .FirstOrDefaultAsync();
        }

        public async Task<GiftCard> GiftCarForUpdatedAsync(int giftCardId)
        {
            return await context.GiftCards.Where(m => m.IsDeleted == false && m.Id == giftCardId)
                                           .AsNoTracking()
                                           .FirstOrDefaultAsync();
        }
    }
}
