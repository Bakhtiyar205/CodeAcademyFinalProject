﻿using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.Utilities.Files;
using BackFinalProject.Utilities.Helpers;
using BackFinalProject.Utilities.Pagination;
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
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryService subCategoryService;
        private readonly IWebHostEnvironment environment;
        private readonly AppDBContext context;

        public SubCategoryController(ISubCategoryService subCategoryService,
                                     IWebHostEnvironment environment,
                                     AppDBContext context)
        {
            this.subCategoryService = subCategoryService;
            this.environment = environment;
            this.context = context;
        }
        public async Task<IActionResult> Index(int? take, int? page)
        {
            Paginate<SubCategory> subCategory = await subCategoryService.GetPaginateSubCategoryAsync(take,page);
            return View(subCategory);
        }

        public async Task<IActionResult> Create()
        {
            var categories = await context.Categories.Where(m => !m.İsDeleted).ToListAsync();

            ViewBag.GetCategories = await GetSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubCategory subCategory)
        {
            ViewBag.categories = await GetSelectList();
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View();
            if (ModelState["Name"].ValidationState == ModelValidationState.Invalid) return View();
            if (ModelState["SubCategoryText"].ValidationState == ModelValidationState.Invalid) return View();

            if (!subCategory.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photos", "Only Image Type Is Acceptible");
                return View(subCategory);
            }
            if (!subCategory.Photo.CheckFileSize(400))
            {
                ModelState.AddModelError("Photos", "The File should be less than 400KB");
                return View(subCategory);
            }

            string fileName = Guid.NewGuid().ToString() + "_" + subCategory.Photo.FileName;

            string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/subCategory", fileName);

            await subCategory.Photo.SaveFiles(path);

            subCategory.Image = fileName;

            await context.SubCategories.AddAsync(subCategory);

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int subCategoryId)
        {
            SubCategory subCategory = await subCategoryService.GetSubCategoriesWithIdAsync(subCategoryId);

            if (subCategory == null) return NotFound();
            string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/subCategory", subCategory.Image);
            Helper.DeleteFile(path);
            subCategory.IsDeleted = true;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int subCategoryId)
        {
            SubCategory subCategory = await subCategoryService.GetSubCategoriesWithIdAsync(subCategoryId);

            if (subCategory == null) NotFound();

            ViewBag.SelectList = await GetSelectList();

            return View(subCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int subCategoryId, SubCategory subCategory)
        {
            ViewBag.SelectList = await GetSelectList();
            SubCategory dbSubCategory = await subCategoryService.GetSubCategoriesWithIdAsync(subCategoryId);
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View();
            if (ModelState["Name"].ValidationState == ModelValidationState.Invalid) return View();
            if (ModelState["SubCategoryText"].ValidationState == ModelValidationState.Invalid) return View();

            if (!subCategory.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photos", "Only Image Type Is Acceptible");
                return View(subCategory);
            }
            if (!subCategory.Photo.CheckFileSize(400))
            {
                ModelState.AddModelError("Photos", "The File should be less than 400KB");
                return View(subCategory);
            }
            string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/subCategory", dbSubCategory.Image);
            Helper.DeleteFile(path);
            string fileName = Guid.NewGuid().ToString() + "_" + subCategory.Photo.FileName;
            string newPath = Helper.GetFilePath(environment.WebRootPath, "assets/img/subCategory", fileName);
            await subCategory.Photo.SaveFiles(newPath);
            subCategory.Image = fileName;
            context.SubCategories.Update(subCategory);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int subCategoryId)
        {
            ViewBag.categories = await GetSelectList();
            SubCategory subCategory = await subCategoryService.GetSubCategoriesWithIdAsync(subCategoryId);

            if (subCategory is null) NotFound();

            return View(subCategory);
        }

        private async Task<SelectList> GetSelectList()
        {
            var categories = await context.Categories.Where(m => !m.İsDeleted).ToListAsync();
            return new SelectList(categories, "Id", "Name");
        }
    }
}