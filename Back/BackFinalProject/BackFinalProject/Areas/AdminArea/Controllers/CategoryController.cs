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
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IWebHostEnvironment environment;
        private readonly AppDBContext context;

        public CategoryController(ICategoryService categoryService,
                                  IWebHostEnvironment environment,
                                  AppDBContext context)
        {
            this.categoryService = categoryService;
            this.environment = environment;
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await categoryService.GetCategoriesAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View();
            if (ModelState["Name"].ValidationState == ModelValidationState.Invalid) return View();
            if (ModelState["CategoryText"].ValidationState == ModelValidationState.Invalid) return View();

            if (!category.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photos", "Only Image Type Is Acceptible");
                return View(category);
            }
            if (!category.Photo.CheckFileSize(400))
            {
                ModelState.AddModelError("Photos", "The File should be less than 400KB");
                return View(category);
            }

            string fileName = Guid.NewGuid().ToString() + "_" + category.Photo.FileName.Substring(category.Photo.FileName.IndexOf("."));

            string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/categoriesMainPictures", fileName);

            await category.Photo.SaveFiles(path);

            category.Image = fileName;

            await context.Categories.AddAsync(category);

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int categoryId)
        {
            Category category = await categoryService.GetCategoriesWithIdAsync(categoryId);
            if (category == null) return NotFound();
            string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/categoriesMainPictures", category.Image);
            Helper.DeleteFile(path);
            category.İsDeleted = true;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int categoryId)
        {
            Category category = await categoryService.GetCategoriesWithIdAsync(categoryId);

            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int categoryId,Category category)
        {
            category.Id = categoryId;
            Category dbCategory = await categoryService.GetCategoryAsNoTrackingAsync(categoryId);
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View();
            if (ModelState["Name"].ValidationState == ModelValidationState.Invalid) return View();
            if (ModelState["CategoryText"].ValidationState == ModelValidationState.Invalid) return View();
            if (!category.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photos", "Only Image Type Is Acceptible");
                return View(category);
            }
            if (!category.Photo.CheckFileSize(400))
            {
                ModelState.AddModelError("Photos", "The File should be less than 400KB");
                return View(category);
            }
            if (dbCategory == null) return NotFound();

            string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/categoriesMainPictures", dbCategory.Image);

            Helper.DeleteFile(path);

            string fileName = Guid.NewGuid().ToString() + "_" + category.Photo.FileName.Substring(category.Photo.FileName.IndexOf("."));

            string newPath = Helper.GetFilePath(environment.WebRootPath, "assets/img/categoriesMainPictures", fileName);

            await category.Photo.SaveFiles(newPath);

            category.Image = fileName;

            context.Categories.Update(category);

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int categoryId)
        {
            Category category = await categoryService.GetCategoriesWithIdAsync(categoryId);

            if (category is null) NotFound();

            return View(category);
        }
    }
}
