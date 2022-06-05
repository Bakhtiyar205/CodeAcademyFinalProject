using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
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
                Products = await productService.GetProductWithSubCategoryIdAsync(subCategoryId,1)
            };
            return View(subCategoryVM);
        }

        public async Task<List<Product>> GetProducts(int subCategoryId, int? productPrice)
        {
            if (productPrice == 2)
            {
                return await productService.GetProductWithSubCategoryIdAsync(subCategoryId,(int)productPrice);
            }
            else
            {
                productPrice = 1;
                return await productService.GetProductWithSubCategoryIdAsync(subCategoryId, (int)productPrice);
            }
        }

    }
}
