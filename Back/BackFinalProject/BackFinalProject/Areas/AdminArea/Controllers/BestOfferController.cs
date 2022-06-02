using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.Utilities.Files;
using BackFinalProject.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        private readonly IBestOfferImageService bestOfferImageService;

        public BestOfferController(AppDBContext context,
                                    IWebHostEnvironment environment,
                                    IBestOfferService bestOfferService,
                                    IBestOfferImageService bestOfferImageService)
        {
            this.context = context;
            this.environment = environment;
            this.bestOfferService = bestOfferService;
            this.bestOfferImageService = bestOfferImageService;
        }
       

        public async Task<IActionResult> Index()
        {
            return View(await bestOfferService.GetBestOfferAsync());
        }

        public async Task<IActionResult> Edit()
        {
            return View(await bestOfferService.GetBestOfferAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BestOffer bestOffer)
        {
            if (ModelState["Text"].ValidationState == ModelValidationState.Invalid) return View(bestOffer);
            if(bestOffer.Text != null)
            {
                if (bestOffer.Text.Length > 400)
                {
                    ModelState.AddModelError(nameof(bestOffer.Text), "Text should be less than 400 character");
                    return View(bestOffer);
                }
            }
            context.BestOffers.Update(bestOffer);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ImageList()
        {
            return View(await bestOfferImageService.GetBestOfferImagesAsync());
        }

        public async Task<IActionResult> EditImage(int id)
        {
            BestOfferImages bestOfferImages = await bestOfferImageService.GetOfferImageWithIdAsync(id);
            if (bestOfferImages is null) NotFound();
            return View(bestOfferImages);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditImage(int id, BestOfferImages bestOfferImages)
        {
            BestOfferImages dbBestOfferImage = await bestOfferImageService.GetOfferImageWithIdAsync(id);
            if (dbBestOfferImage is null) NotFound();
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View();
            if (!bestOfferImages.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photos", "Only Image Type Is Acceptible");
                return View(bestOfferImages);
            }
            if (!bestOfferImages.Photo.CheckFileSize(900))
            {
                ModelState.AddModelError("Photos", "The File should be less than 900KB");
                return View(bestOfferImages);

            }
            string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/bestOffer", dbBestOfferImage.Image);
            Helper.DeleteFile(path);
            string fileName = Guid.NewGuid().ToString() + "_" + bestOfferImages.Photo.FileName.Substring(bestOfferImages.Photo.FileName.LastIndexOf("."));
            string newPath = Helper.GetFilePath(environment.WebRootPath, "assets/img/bestOffer", fileName);
            await bestOfferImages.Photo.SaveFiles(newPath);
            bestOfferImages.Image = fileName;
            context.BestOfferImages.Update(bestOfferImages);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateImage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateImage(BestOfferImages bestOfferImages)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View(bestOfferImages);
            if (!bestOfferImages.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Only Image Type Is Acceptible");
                return View(bestOfferImages);
            }
            if (!bestOfferImages.Photo.CheckFileSize(4500))
            {
                ModelState.AddModelError("Photo", "The File should be less than 4500KB");
                return View(bestOfferImages);
            }
            string fileName = Guid.NewGuid().ToString() + "_" + bestOfferImages.Photo.FileName.Substring(bestOfferImages.Photo.FileName.IndexOf("."));
            string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/bestOffer", fileName);
            await bestOfferImages.Photo.SaveFiles(path);
            bestOfferImages.Image = fileName;
            await context.BestOfferImages.AddAsync(bestOfferImages);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            BestOfferImages bestOfferImages = await bestOfferImageService.GetOfferImageWithIdAsync(id);
            if (bestOfferImages is null) NotFound();
            string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/bestOffer", bestOfferImages.Image);
            Helper.DeleteFile(path);
            bestOfferImages.IsDeleted = true;
            context.BestOfferImages.Update(bestOfferImages);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(ImageList));
        }

    }
}
