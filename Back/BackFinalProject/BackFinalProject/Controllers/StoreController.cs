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
        private readonly IProductService productService;

        public StoreController(ISettingService settingService,
                               IProductService productService)
        {
            this.settingService = settingService;
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            StoreVM storeVM = new()
            {
                Setting = settingService.GetSetting(),
                Products = await productService.GetProductsAsync()
            };
            return View(storeVM);
        }
    }
}
