using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            this.subCategoryService = subCategoryService;
        }
        public async Task<IActionResult> Index(int subCategoryId)
        {
            SubCategoryVM subCategoryVM = new()
            {
                SubCategory = await subCategoryService.GetSubCategoriesWithIdAsync(subCategoryId)
            };
            return View(subCategoryVM);
        }
    }
}
