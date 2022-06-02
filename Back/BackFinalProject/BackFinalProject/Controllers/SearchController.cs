using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            List<Product> products = await productService.GetNewOutletProductsAsync();
            List<Product> productResults = new();
            
            if(search != null)
            {
                foreach (var product in products)
                {
                    if (product.Name.ToLower().Trim().Contains(search.ToLower().Trim()))
                    {
                        productResults.Add(product);
                    }
                }
            }
            

            return View(productResults);
        }

        [HttpGet]
        public async Task<JsonResult> Products(string search)
        {
            List<Product> products = await productService.GetNewOutletProductsAsync();
            List<Product> productResults = new();
            foreach (var product in products)
            {
                if (product.Name.ToLower().Trim().Contains(search.ToLower().Trim()))
                {
                    productResults.Add(product);
                }
            }
            return Json(productResults);
        }
    }
}
