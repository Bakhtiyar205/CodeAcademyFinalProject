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
    public class SettingService : ISettingService
    {
        private readonly AppDBContext context;

        public SettingService(AppDBContext context)
        {
            this.context = context;
        }

        public Dictionary<string,string> GetSetting()
        {
            Dictionary<string, string> settings = context.Settings.ToDictionary(m => m.Key, m => m.Value);
            return settings;
        }

        public async Task<List<Setting>> GetListSettingsAsync()
        {
            return await context.Settings.ToListAsync();
        }

        public async Task<Setting> GetSettingWithIdAsync(int settingId)
        {
            return await context.Settings.AsNoTracking().FirstOrDefaultAsync(m => m.Id == settingId);
        }
    }
}
