using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.Utilities.Files;
using BackFinalProject.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class DiscountCategoryController : Controller
    {
        private readonly AppDBContext context;
        private readonly IDiscountCategoryService discountCategoryService;
        private readonly IWebHostEnvironment environment;

        public DiscountCategoryController(AppDBContext context,
                                          IDiscountCategoryService discountCategoryService,
                                          IWebHostEnvironment environment)
        {
            this.context = context;
            this.discountCategoryService = discountCategoryService;
            this.environment = environment;
        }
        public async Task<IActionResult> Index()
        {
            return View(await discountCategoryService.GetDiscountCategroyAsync());
        }

        public async Task<IActionResult> Edit()
        {
            ViewBag.GetCategories = await GetSelectList();
            return View(await discountCategoryService.GetDiscountCategroyAsync());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DiscountCategroy categroy)
        {
            ViewBag.GetCategories = await GetSelectList();
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View(categroy);
            if (ModelState["Name"].ValidationState == ModelValidationState.Invalid) return View(categroy);
            if (ModelState["DiscountCategoryText"].ValidationState == ModelValidationState.Invalid) return View(categroy);
            if(categroy.Name.Length > 100)
            {
                ModelState.AddModelError(nameof(categroy.Name), "Name should be less than 100 characters");
                return View(categroy);
            }
            if(categroy.DiscountCategoryText != null)
            {
                if (categroy.DiscountCategoryText.Length > 255)
                {
                    ModelState.AddModelError(nameof(categroy.DiscountCategoryText), "DiscountCategoryText should be less than 255 characters");
                    return View(categroy);
                }
            }
            if (!categroy.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photos", "Only Image Type Is Acceptible");
                return View(categroy);
            }
            if (!categroy.Photo.CheckFileSize(900))
            {
                ModelState.AddModelError("Photos", "The File should be less than 400KB");
                return View(categroy);
            }
            DiscountCategroy dbCategory = await discountCategoryService.GetDiscountCategroyCrudAsync();
            string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/categoriesDiscount", dbCategory.Image);
            Helper.DeleteFile(path);
            string fileName = Guid.NewGuid().ToString() + "_" + categroy.Photo.FileName.Substring(categroy.Photo.FileName.IndexOf("."));
            string newPath = Helper.GetFilePath(environment.WebRootPath, "assets/img/categoriesDiscount", fileName);
            await categroy.Photo.SaveFiles(newPath);
            dbCategory.Image = fileName;
            dbCategory.Photo = categroy.Photo;
            dbCategory.Name = categroy.Name;
            dbCategory.DiscountCategoryText = categroy.DiscountCategoryText;
            dbCategory.CategoryId = categroy.CategoryId;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<SelectList> GetSelectList()
        {
            var categories = await context.Categories.Where(m => !m.İsDeleted).ToListAsync();
            return new SelectList(categories, "Id", "Name");
        }
    }
}
