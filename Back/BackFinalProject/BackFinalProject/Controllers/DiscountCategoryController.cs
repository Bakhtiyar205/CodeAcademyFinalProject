using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class DiscountCategoryController : Controller
    {
        private readonly IDiscountCategoryService discountCategoryService;

        public DiscountCategoryController(IDiscountCategoryService discountCategoryService)
        {
            this.discountCategoryService = discountCategoryService;
        }
        public async Task<IActionResult> Index()
        {
            DiscountCategoryVM discountCategoryVM = new()
            {
                DiscountCategroy = await discountCategoryService.GetDiscountCategroyAsync()
            };
            return View(discountCategoryVM);
        }
    }
}
