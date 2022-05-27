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
    public class BrendService : IBrendService
    {
        private readonly AppDBContext context;

        public BrendService(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<Brend> GetBrendWithIdAsync(int brendId)
        {
            return await context.Brends.Where(m => m.Id == brendId).FirstOrDefaultAsync();
        }

        public async Task<List<Brend>> GetBrendsAsync()
        {
            return await context.Brends.Where(m=>!m.IsDeleted).ToListAsync();
        }

    }
}
