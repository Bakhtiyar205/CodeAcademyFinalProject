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
        private readonly IProductService productService;

        public SubCategoryController(ISubCategoryService subCategoryService,
                                        IProductService productService)
        {
            this.subCategoryService = subCategoryService;
            this.productService = productService;
        }
        public async Task<IActionResult> Index(int subCategoryId)
        {
            
            SubCategoryVM subCategoryVM = new()
            {
                SubCategory = await subCategoryService.GetSubCategoriesWithIdAsync(subCategoryId),
                Products = await productService.GetProductWithSubCategoryIdAsync(subCategoryId)
            };
            return View(subCategoryVM);
        }
    }
}
