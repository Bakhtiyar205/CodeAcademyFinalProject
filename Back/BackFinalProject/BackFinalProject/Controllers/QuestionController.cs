using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class QuestionController : Controller
    {
        private readonly ISettingService settingService;
        private readonly IProductService productService;

        public QuestionController(ISettingService settingService,
                                  IProductService productService)
        {
            this.settingService = settingService;
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
            QuestionVM questionVM = new()
            {
                Settings = settingService.GetSetting(),
                Products = await productService.GetProductsAsync(),
                WishListCount = wishListCount,
                WishListVM = wishListVM
            };
            return View(questionVM);
        }
    }
}
