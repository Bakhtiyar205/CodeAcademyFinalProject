using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class BrendController : Controller
    {
        private readonly IBrendService brendService;

        public BrendController(IBrendService brendService)
        {
            this.brendService = brendService;
        }
        public async Task<IActionResult> BrendDetail(int brendId)
        {
            BrendVM brendVM = new()
            {
                Brend = await brendService.GetBrendWithIdAsync(brendId)
            };
            return View(brendVM);
        }

        public async Task<IActionResult> Index()
        {
            BrendsVM brendsVM = new()
            {
                Brends = await brendService.GetBrendsAsync()
            };
            return View(brendsVM);
        }
    }
}
