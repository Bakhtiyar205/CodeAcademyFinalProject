using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
        private readonly IProductService productService;

        public HeaderViewComponent(ICategoryService categoryService,
                                   ISubCategoryService subCategoryService,
                                   ISettingService settingService,
                                   IProductService productService)
        {
            this.categoryService = categoryService;
            this.subCategoryService = subCategoryService;
            this.settingService = settingService;
            this.productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Category> categories = await categoryService.GetCategoriesAsync();
            List<SubCategory> subCategories = await subCategoryService.GetSubCategoriesAsync();
            Dictionary<string, string> settings = settingService.GetSetting();
            int basketProductsCount = 0;
            if(Request.Cookies["basket"] != null)
            {
                basketProductsCount = JsonConvert.DeserializeObject<List<BasketCookieVM>>(Request.Cookies["basket"]).Count();
            }

            HeaderVM headerVM = new HeaderVM()
            {
                Categories = categories,
                SubCategories = subCategories,
                Settings = settings,
                BasketProductCount = basketProductsCount
            };

            return await Task.FromResult(View(headerVM));
        }
    }
}
                        