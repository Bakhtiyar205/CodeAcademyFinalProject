using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.Utilities.Files;
using BackFinalProject.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]

    public class GiftCardController : Controller
    {
        private readonly AppDBContext context;
        private readonly IGiftCardService cardService;
        private readonly IWebHostEnvironment environment;

        public GiftCardController(AppDBContext context,
                                   IGiftCardService cardService,
                                   IWebHostEnvironment environment)
        {
            this.context = context;
            this.cardService = cardService;
            this.environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            return View(await cardService.GiftCardsAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GiftCard giftCard)
        {
            if (!ModelState.IsValid) return View(giftCard);
            if (!giftCard.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photos", "Only Image Type Is Acceptible");
                return View(giftCard);
            }
            if (!giftCard.Photo.CheckFileSize(400))
            {
                ModelState.AddModelError("Photos", "The File should be less than 400KB");
                return View(giftCard);
            }
            string fileName = Guid.NewGuid().ToString() + "_" + giftCard.Photo.FileName.Substring(giftCard.Photo.FileName.IndexOf("."));
            string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/giftCard", fileName);
            await giftCard.Photo.SaveFiles(path);
            giftCard.Image = fileName;
            await context.GiftCards.AddAsync(giftCard);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            GiftCard gift = await cardService.GiftCarForUpdatedAsync(id);
            if (gift is null) return View(gift);
            return View(gift);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GiftCard giftCard)
        {
            if (!ModelState.IsValid) return View(giftCard);
            GiftCard dbGiftCard = await cardService.GiftCarForUpdatedAsync(id);
            if (dbGiftCard is null) return NotFound();
            if (!giftCard.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photos", "Only Image Type Is Acceptible");
                return View(dbGiftCard);
            }
            if (!giftCard.Photo.CheckFileSize(400))
            {
                ModelState.AddModelError("Photos", "The File should be less than 400KB");
                return View(dbGiftCard);
            }
            string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/giftCard", dbGiftCard.Image);
            Helper.DeleteFile(path);
            string fileName = Guid.NewGuid().ToString() + "_" + giftCard.Photo.FileName.Substring(giftCard.Photo.FileName.IndexOf("."));
            string newPath = Helper.GetFilePath(environment.WebRootPath, "assets/img/giftCard", fileName);
            await giftCard.Photo.SaveFiles(newPath);
            giftCard.Image = fileName;
            context.GiftCards.Update(giftCard);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            GiftCard giftCard = await cardService.GiftCarWithIddAsync(id);
            if (giftCard is null) NotFound();
            string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/giftCard", giftCard.Image);
            Helper.DeleteFile(path);
            giftCard.IsDeleted = true;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            GiftCard giftCard = await cardService.GiftCarWithIddAsync(id);
            if (giftCard is null) NotFound();
            return View(giftCard);
        }
    }
}
