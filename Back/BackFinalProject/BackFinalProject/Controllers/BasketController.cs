using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    [Authorize]
    public class BasketController : Controller
    {
        private readonly IProductService productService;

        public BasketController(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            List<BasketDetailVM> basketDetailItems = new List<BasketDetailVM>();
            if (Request.Cookies["basket"] != null)
            {
                List<BasketCookieVM> baskets = JsonConvert.DeserializeObject<List<BasketCookieVM>>(Request.Cookies["basket"]);
               
                foreach (BasketCookieVM basket in baskets)
                {
                    Product product = await productService.GetProductWithIdAsync(basket.Id);

                    BasketDetailVM basketDetail = new()
                    {
                        Product = product,
                        ProductCount = basket.Count
                    };

                    basketDetailItems.Add(basketDetail);
                }
            }
            return View(basketDetailItems);
        }
    }
}
