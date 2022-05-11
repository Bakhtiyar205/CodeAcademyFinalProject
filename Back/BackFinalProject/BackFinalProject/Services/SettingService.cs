using BackFinalProject.Datas;
using BackFinalProject.Services.Interfaces;
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
    }
}
