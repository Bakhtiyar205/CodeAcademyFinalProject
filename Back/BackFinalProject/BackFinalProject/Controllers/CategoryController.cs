using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            int wishListCount = 0;
            List<WishListVM> wishListVM = new();
            if (Request.Cookies["wishList"] != null)
            {
                wishListCount = JsonConvert.DeserializeObject<List<WishListVM>>(Request.Cookies["wishList"]).Count();
                wishListVM = JsonConvert.DeserializeObject<List<WishListVM>>(Request.Cookies["wishList"]);
            }
            CategoryVM categoryVM = new()
            {
                Category = await categoryService.GetCategoriesWithIdAsync(categoryId),
                Products = await productService.GetPaginateOutletProductsAsync(8,page),
                WishListCount = wishListCount,
                WishListVM = wishListVM
            };

            

            return View(categoryVM);
        }
    }
}
