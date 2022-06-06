using BackFinalProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackFinalProject.Services.Interfaces
{
    public interface ISettingService
    {
        Dictionary<string, string> GetSetting();
        Task<List<Setting>> GetListSettingsAsync();
        Task<Setting> GetSettingWithIdAsync(int settingId);
    }
}
