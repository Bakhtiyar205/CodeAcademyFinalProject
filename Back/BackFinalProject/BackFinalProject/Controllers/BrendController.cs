﻿using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class BrendController : Controller
    {
        private readonly IBrendService brendService;
        private readonly IProductService productService;

        public BrendController(IBrendService brendService,
                               IProductService productService)
        {
            this.brendService = brendService;
            this.productService = productService;
        }
        public async Task<IActionResult> BrendDetail(int brendId)
        {
            int wishListCount = 0;
            if (Request.Cookies["wishList"] != null)
            {
                wishListCount = JsonConvert.DeserializeObject<List<WishListVM>>(Request.Cookies["wishList"]).Count();
            }
            BrendVM brendVM = new()
            {
                Brend = await brendService.GetBrendWithIdAsync(brendId),
                Products = await productService.GetProductsAsync(),
                WishListCount = wishListCount
            };
            return View(brendVM);
        }

        public async Task<IActionResult> Index()
        {
            int wishListCount = 0;
            if (Request.Cookies["wishList"] != null)
            {
                wishListCount = JsonConvert.DeserializeObject<List<WishListVM>>(Request.Cookies["wishList"]).Count();
            }
            BrendsVM brendsVM = new()
            {
                Brends = await brendService.GetBrendsAsync(),
                Products = await productService.GetProductsAsync(),
                WishListCount = wishListCount
            };
            return View(brendsVM);
        }
    }
}
