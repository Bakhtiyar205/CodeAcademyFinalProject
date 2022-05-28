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
    public class BestOfferImageService : IBestOfferImageService
    {
        private readonly AppDBContext context;

        public BestOfferImageService(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<List<BestOfferImages>> GetBestOfferImagesAsync()
        {
            return await context.BestOfferImages.Where(m => !m.IsDeleted).ToListAsync();
        }

        public async Task<BestOfferImages> GetOfferImageWithIdAsync(int id)
        {
            return await context.BestOfferImages.Where(m => !m.IsDeleted && m.Id == id)
                                                .AsNoTracking()
                                                .FirstOrDefaultAsync();
        }
    }
}
