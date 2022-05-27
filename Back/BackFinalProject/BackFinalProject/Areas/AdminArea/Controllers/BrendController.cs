using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services;
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
    public class BrendController : Controller
    {
        private readonly IBrendService brendService;
        private readonly AppDBContext context;
        private readonly IWebHostEnvironment environment;

        public BrendController(IBrendService brendService,
                                AppDBContext context,
                                IWebHostEnvironment environment)
        {
            this.brendService = brendService;
            this.context = context;
            this.environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await brendService.GetBrendsAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brend brend)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View();
            if (ModelState["Name"].ValidationState == ModelValidationState.Invalid) return View();
            if (ModelState["Text"].ValidationState == ModelValidationState.Invalid) return View();
            if (!brend.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photos", "Only Image Type Is Acceptible");
                return View(brend);
            }
            if (!brend.Photo.CheckFileSize(400))
            {
                ModelState.AddModelError("Photos", "The File should be less than 400KB");
                return View(brend);
            }
            string fileName = Guid.NewGuid().ToString() + "_" + brend.Photo.FileName;
            string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/brendSearch", fileName);
            await brend.Photo.SaveFiles(path);
            brend.Image = fileName;
            await context.Brends.AddAsync(brend);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int brendId)
        {
            Brend brend = await brendService.GetBrendWithIdAsync(brendId);

            if (brend == null) NotFound();

            return View(brend);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int brendId, Brend brend)
        {
            Brend dbBrend = await brendService.GetBrendWithIdAsync(brendId);
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View();
            if (ModelState["Name"].ValidationState == ModelValidationState.Invalid) return View();
            if (ModelState["Text"].ValidationState == ModelValidationState.Invalid) return View();
            if (!brend.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photos", "Only Image Type Is Acceptible");
                return View(brend);
            }
            if (!brend.Photo.CheckFileSize(400))
            {
                ModelState.AddModelError("Photos", "The File should be less than 400KB");
                return View(brend);
            }
            if (dbBrend == null) return NotFound();
            string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/brendSearch", dbBrend.Image);
            Helper.DeleteFile(path);
            string fileName = Guid.NewGuid().ToString() + "_" + brend.Photo.FileName;
            string newPath = Helper.GetFilePath(environment.WebRootPath, "assets/img/brendSearch", fileName);
            await brend.Photo.SaveFiles(newPath);
            brend.Image = fileName;
            context.Brends.Update(brend);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int brendId)
        {
            Brend brend = await brendService.GetBrendWithIdAsync(brendId);
            if (brend == null) NotFound();
            string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/brendSearch", brend.Image);
            Helper.DeleteFile(path);
            brend.IsDeleted = true;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int brendId)
        {
            Brend brend = await brendService.GetBrendWithIdAsync(brendId);
            if (brend == null) NotFound();
            return View(brend);
        }
    }
}
