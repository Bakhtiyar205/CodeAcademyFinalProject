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
        private readonly IProductService productService;

        public DiscountCategoryController(IDiscountCategoryService discountCategoryService,
                                          IProductService productService)
        {
            this.discountCategoryService = discountCategoryService;
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            int wishListCount = 0;
            List<WishListVM> wishListVM = new();
            if (Request.Cookies["wishList"] != null)
            {
                wishListCount = JsonConvert.DeserializeObject<List<WishListVM>>(Request.Cookies["wishList"]).Count();
                wishListVM = JsonConvert.DeserializeObject<List<WishListVM>>(Request.Cookies["wishList"]);
            }
            DiscountCategoryVM discountCategoryVM = new()
            {
                DiscountCategroy = await discountCategoryService.GetDiscountCategroyAsync(),
                Products = await productService.GetProductsAsync(),
                WishListCount = wishListCount,
                WishListVM = wishListVM
            };
            return View(discountCategoryVM);
        }
    }
}
