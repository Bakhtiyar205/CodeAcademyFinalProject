using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class GiftCardController : Controller
    {
        private readonly IGiftCardService giftCardService;
        private readonly ICategoryService categoryService;

        public GiftCardController(IGiftCardService giftCardService,
                                  ICategoryService categoryService)
        {
            this.giftCardService = giftCardService;
            this.categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            GiftCardsVM giftCardsVM = new()
            {
                GiftCards = await giftCardService.GiftCardsAsync()
            };
            return View(giftCardsVM);
        }

        public async Task<IActionResult> GiftCardDetail(int giftCardId)
        {
            GiftCardDetailVM giftCardDetail = new()
            {
                GiftCard = await giftCardService.GiftCarWithIddAsync(giftCardId),
                Categories = await categoryService.GetCategoriesAsync()

            };
            return View(giftCardDetail);
        }
    }
}
