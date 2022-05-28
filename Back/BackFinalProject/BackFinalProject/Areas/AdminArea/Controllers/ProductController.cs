using BackFinalProject.Areas.AdminArea.ViewModels;
using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.Utilities.Files;
using BackFinalProject.Utilities.Helpers;
using BackFinalProject.Utilities.Pagination;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class ProductController : Controller
    {
        private readonly AppDBContext context;
        private readonly IWebHostEnvironment environment;
        private readonly IProductService productService;

        public ProductController(AppDBContext context,
                                 IWebHostEnvironment environment,
                                 IProductService productService)
        {
            this.context = context;
            this.environment = environment;
            this.productService = productService;
        }
        public async Task<IActionResult> Index(int? take, int? page)
        {
            Paginate<Product> products = await productService.GetAllProductsAsync(take, page);
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.SelectList = await GetSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateVM product)
        {
            if (!ModelState.IsValid) return View(product);
            foreach (var photo in product.Photos)
            {
                if (!photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "Only image type is accebtible");
                    return View();
                }

                if (!photo.CheckFileSize(400))
                {
                    ModelState.AddModelError("Photo", "Must be Less than 200KB");
                    return View();
                }
            }
            Product newProduct = new()
            {
                Name = product.Name,
                Detail = product.Detail,
                Discount = product.Discount,
                RealPrice = product.RealPrice,
                IsOutlet = product.IsOutlet,
                IsOnline = product.IsOnline,
                IsDeleted = false,
                SubCategoryId = product.SubCategoryId
            };
            await context.Products.AddAsync(newProduct);
            foreach (var photo in product.Photos)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/products", fileName);
                await photo.SaveFiles(path);
                ProductImage productImage = new()
                {
                    Image = fileName,
                    ProductId = newProduct.Id,
                    Product = newProduct
                };
                await context.ProductImages.AddAsync(productImage);
            }
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await productService.GetProductWithIdAsync(id);
            if (product is null) return NotFound();
            foreach (var item in product.ProductImages)
            {
                string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/products", item.Image);
                Helper.DeleteFile(path);
            }
            product.IsDeleted = true;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            Product product = await productService.GetOutletProductWithIdAsync(id);
            if (product is null) NotFound();
            return View(product);
        }
        private async Task<SelectList> GetSelectList()
        {
            var subCategories = await context.SubCategories.Where(m => !m.IsDeleted).ToListAsync();
            return new SelectList(subCategories, "Id", "Name");
        }
    }
}
