using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly IProductService productService;

        public ProductDetailController(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> Index(int productId)
        {
            ProductVM productVM = new(await productService.GetProductWithIdAsync(productId))
            {
                Product = await productService.GetProductWithIdAsync(productId),
                Products = await productService.GetProductsAsync()
            };
            return View(productVM);
        }
    }
}
