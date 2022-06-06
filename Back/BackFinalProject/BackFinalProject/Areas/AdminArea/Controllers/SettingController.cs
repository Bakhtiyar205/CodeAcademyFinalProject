using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackFinalProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    [Authorize(Roles = "Admin")]
    public class SettingController : Controller
    {
        private readonly ISettingService settingService;
        private readonly AppDBContext context;

        public SettingController(ISettingService settingService,AppDBContext context)
        {
            this.settingService = settingService;
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await settingService.GetListSettingsAsync());
        }

        public async Task<IActionResult> Edit(int settingId)
        {
            
            Setting setting = await settingService.GetSettingWithIdAsync(settingId);
            if (setting == null) NotFound();
            return View(setting);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int settingId, Setting setting)
        {
            if (!ModelState.IsValid) return View();
            if(setting.Value.Length > 255)
            {
                ModelState.AddModelError(nameof(setting.Value), "Character should be less than 255");
            }
            if (settingId != setting.Id) return View();
            try
            {
                Setting dbSetting = await settingService.GetSettingWithIdAsync(settingId);
                if (dbSetting.Value.ToLower().Trim() == setting.Value.ToLower().Trim())
                    return RedirectToAction(nameof(Index));

                dbSetting.Value = setting.Value;
                setting.Key = dbSetting.Key;
                context.Settings.Update(setting);

                await context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));

            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }
    }
}
