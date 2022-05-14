using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
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
            BestOfferVM bestOfferVM = new()
            {
                BestOffer = await bestOfferService.GetBestOfferAsync()
            };
            return View(bestOfferVM);
        }
    }
}
