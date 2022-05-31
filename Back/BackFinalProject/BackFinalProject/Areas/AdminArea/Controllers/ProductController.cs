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
        private readonly IProductImageService productImageService;

        public ProductController(AppDBContext context,
                                 IWebHostEnvironment environment,
                                 IProductService productService,
                                 IProductImageService productImageService)
        {
            this.context = context;
            this.environment = environment;
            this.productService = productService;
            this.productImageService = productImageService;
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
                string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName.Substring(photo.FileName.IndexOf("."));
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


        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.SelectList = await GetSelectList();
            Product product = await productService.GetProductWithIdAsync(id);
            if (product is null) return NotFound();
            ProductUpdateVM productUpdate = new()
            {
                Product = product
            };
            return View(productUpdate);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,ProductUpdateVM productUpdate)
        {
            ViewBag.SelectList = await GetSelectList();
            if (productUpdate.Product.ProductImages != null)
            {
                foreach (var formPhoto in productUpdate.Product.ProductImages)
                {
                    if(formPhoto.FormPhoto != null)
                    {
                        if (!formPhoto.FormPhoto.CheckFileType("image/"))
                        {
                            ModelState.AddModelError("Photo", "Only image type is accebtible");
                            return View();
                        }

                        if (!formPhoto.FormPhoto.CheckFileSize(800))
                        {
                            ModelState.AddModelError("Photo", "Must be Less than 800KB");
                            return View();
                        }
                    }
                    

                }
            }
            if(productUpdate.Photos != null)
            {
                foreach (var photo in productUpdate.Photos)
                {
                        if (!photo.CheckFileType("image/"))
                        {
                            ModelState.AddModelError("Photo", "Only image type is accebtible");
                            return View();
                        }

                        if (!photo.CheckFileSize(800))
                        {
                            ModelState.AddModelError("Photo", "Must be Less than 800KB");
                            return View();
                        }
                }

            }
            Product dbProduct = await productService.GetProductWithIdAsync(id);
            if (dbProduct is null) return NotFound();
            dbProduct.Name = productUpdate.Product.Name;
            dbProduct.Detail = productUpdate.Product.Detail;
            dbProduct.Discount = productUpdate.Product.Discount;
            dbProduct.RealPrice = productUpdate.Product.RealPrice;
            dbProduct.IsOnline = productUpdate.Product.IsOnline;
            dbProduct.IsOutlet = productUpdate.Product.IsOutlet;
            dbProduct.SubCategoryId = productUpdate.Product.SubCategoryId;
            foreach (var productImage in productUpdate.Product.ProductImages)
            {
                ProductImage productUpdateImage = await productImageService.ProductImageWithIdAsync(productImage.Id);
                productUpdateImage.IsDeleted = productImage.IsDeleted;
                if (productImage.FormPhoto != null)
                {
                    string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/products", productImage.Image);
                    Helper.DeleteFile(path);
                    string fileName = Guid.NewGuid().ToString() + "_" + productImage.FormPhoto.FileName;
                    string newPath = Helper.GetFilePath(environment.WebRootPath, "assets/img/products", fileName);
                    await productImage.FormPhoto.SaveFiles(newPath);
                    productUpdateImage.Image = fileName;
                }
            }
            if(productUpdate.Photos != null)
            {
                foreach (var photo in productUpdate.Photos)
                {
                    string fileName = Guid.NewGuid().ToString() + "_" + photo.FileName.Substring(photo.FileName.IndexOf("."));
                    string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/products", fileName);
                    await photo.SaveFiles(path);
                    ProductImage productImage = new()
                    {
                        Image = fileName,
                        ProductId = dbProduct.Id
                    };
                    await context.ProductImages.AddAsync(productImage);
                }
            }
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
