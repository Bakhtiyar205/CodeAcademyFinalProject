using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class StoreController : Controller
    {
        private readonly ISettingService settingService;

        public StoreController(ISettingService settingService)
        {
            this.settingService = settingService;
        }
        public IActionResult Index()
        {
            StoreVM storeVM = new()
            {
                Setting = settingService.GetSetting()
            };
            return View(storeVM);
        }
    }
}
