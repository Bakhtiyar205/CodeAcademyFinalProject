using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class SearchController : Controller
    {
        private readonly IProductService productService;

        public SearchController(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> Index(string search)
        {
            List<Product> products = await productService.GetProductsAsync();
            List<Product> productResults = new();

            foreach (var product in products)
            {
                if (product.Name.ToLower().Trim().Contains(search.ToLower().Trim()))
                {
                    productResults.Add(product);
                }
            }
            return View(productResults);
        }
    }
}
