using BackFinalProject.Datas;
using BackFinalProject.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class BestOfferController : Controller
    {
        private readonly AppDBContext context;
        private readonly IWebHostEnvironment environment;
        private readonly IBestOfferService bestOfferService;

        public BestOfferController(AppDBContext context,
                                    IWebHostEnvironment environment,
                                    IBestOfferService bestOfferService)
        {
            this.context = context;
            this.environment = environment;
            this.bestOfferService = bestOfferService;
        }
       

        public async Task<IActionResult> Index()
        {
            return View(await bestOfferService.GetBestOfferAsync());
        }

        public async Task<IActionResult> Edit()
        {
            return View(await bestOfferService.GetBestOfferAsync());
        }


    }
}
