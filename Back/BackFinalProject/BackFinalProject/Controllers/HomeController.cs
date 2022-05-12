using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly ISettingService settingService;
        private readonly IBrendService brendService;

        public HomeController(ICategoryService categoryService,
                                ISettingService settingService,
                                IBrendService brendService)
        {
            this.categoryService = categoryService;
            this.settingService = settingService;
            this.brendService = brendService;
        }
        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new()
            {
                Categories = await categoryService.GetCategoriesAsync(),
                Setting = settingService.GetSetting(),
                Brends = await brendService.GetBrendsAsync()
            };
            return View(homeVM);
        }
    }
}
