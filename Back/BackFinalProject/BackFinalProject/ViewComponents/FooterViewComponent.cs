using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly ISettingService settingService;
        private readonly ICategoryService categoryService;

        public FooterViewComponent(ISettingService settingService,ICategoryService categoryService)
        {
            this.settingService = settingService;
            this.categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            FooterVM footerVM = new()
            {
                Settings = settingService.GetSetting(),
                Categories = await categoryService.GetCategoriesAsync()
            };

            return await Task.FromResult(View(footerVM));
        }
    }
}
