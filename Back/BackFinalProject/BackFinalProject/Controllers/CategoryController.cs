using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public CategoryController(ICategoryService categoryService,IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }
        public async Task<IActionResult> Index(int categoryId, int? page)
        {
            CategoryVM categoryVM = new()
            {
                Category = await categoryService.GetCategoriesWithIdAsync(categoryId),
                Products = await productService.GetPaginateOutletProductsAsync(9,page)
            };

            

            return View(categoryVM);
        }
    }
}
