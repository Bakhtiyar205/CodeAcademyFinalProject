using BackFinalProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IProductService productService;

        public CatalogController(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await productService.GetProductsAsync());
        }
    }
}
