using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            int wishListCount = 0;
            if (Request.Cookies["wishList"] != null)
            {
                wishListCount = JsonConvert.DeserializeObject<List<WishListVM>>(Request.Cookies["wishList"]).Count();
            }
            DiscountCategoryVM discountCategoryVM = new()
            {
                DiscountCategroy = await discountCategoryService.GetDiscountCategroyAsync(),
                WishListCount = wishListCount
            };
            return View(discountCategoryVM);
        }
    }
}
