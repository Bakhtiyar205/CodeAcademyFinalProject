using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductService productService;

        public CatalogController(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            int wishListCount = 0;
            if (Request.Cookies["wishList"] != null)
            {
                wishListCount = JsonConvert.DeserializeObject<List<WishListVM>>(Request.Cookies["wishList"]).Count();
            }
            ViewBag.WishListCount = wishListCount;
            return View(await productService.GetProductsAsync());
        }
    }
}
