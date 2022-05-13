using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Services
{
    public class BestOfferService : IBestOfferService
    {
        private readonly AppDBContext context;

        public BestOfferService(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<BestOffer> GetBestOfferAsync()
        {
            return await context.BestOffers.Where(m => m.IsDeleted == false)
                                            .Include(m=>m.Images)
                                            .OrderByDescending(m => m.Id)
                                            .FirstOrDefaultAsync();
        }
    }
}
