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
    public class HeaderViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;
        private readonly ISubCategoryService subCategoryService;
        private readonly ISettingService settingService;

        public HeaderViewComponent(ICategoryService categoryService,
                                   ISubCategoryService subCategoryService,
                                   ISettingService settingService)
        {
            this.categoryService = categoryService;
            this.subCategoryService = subCategoryService;
            this.settingService = settingService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories = await categoryService.GetCategoriesAsync();
            List<SubCategory> subCategories = await subCategoryService.GetSubCategoriesAsync();
            Dictionary<string, string> settings = settingService.GetSetting();

            HeaderVM headerVM = new HeaderVM()
            {
                Categories = categories,
                SubCategories = subCategories,
                Settings = settings
            };

            return await Task.FromResult(View(headerVM));
        }
    }
}
                        