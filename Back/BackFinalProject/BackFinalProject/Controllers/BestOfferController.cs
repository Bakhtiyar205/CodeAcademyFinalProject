using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class BestOfferController : Controller
    {
        private readonly IBestOfferService bestOfferService;

        public BestOfferController(IBestOfferService bestOfferService)
        {
            this.bestOfferService = bestOfferService;
        }
        public async Task<IActionResult> Index()
        {
            int wishListCount = 0;
            if (Request.Cookies["wishList"] != null)
            {
                wishListCount = JsonConvert.DeserializeObject<List<WishListVM>>(Request.Cookies["wishList"]).Count();
            }
            BestOfferVM bestOfferVM = new()
            {
                BestOffer = await bestOfferService.GetBestOfferAsync(),
                WishListCount = wishListCount,
            };
            return View(bestOfferVM);
        }
    }
}
