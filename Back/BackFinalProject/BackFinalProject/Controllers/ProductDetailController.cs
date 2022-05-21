using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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


        [HttpPost]
        public async Task<BasketCookieVM> AddBasket(int? productId)
        {
            if (productId is null) BadRequest();

            Product product = await productService.GetProductWithIdAsync((int)productId);

            List<BasketCookieVM> basket = GetBasket();

            UpdateBasket(basket, product);

            //await UpdateBasketDatas(basket);

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));

            return UpdateBasket(basket,product);
        }

        //public async Task<List<BasketDetailVM>> UpdateBasketDatas(List<BasketCookieVM> baskets)
        //{
        //    List<BasketDetailVM> basketDetailItems = new List<BasketDetailVM>();

        //    foreach (BasketCookieVM basket in baskets)
        //    {
        //        Product product = await productService.GetProductWithIdAsync(basket.Id);

        //        BasketDetailVM basketDetail = new()
        //        {
        //            Product = product,
        //            ProductCount = basket.Count
        //        };

        //        basketDetailItems.Add(basketDetail);

        //    }

        //    return basketDetailItems;
        //}

        private List<BasketCookieVM> GetBasket()
        {
            List<BasketCookieVM> basket;

            if(Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketCookieVM>>(Request.Cookies["basket"]);
            }
            else
            {
                basket = new List<BasketCookieVM>();
            }

            return basket;
        }

        public BasketCookieVM UpdateBasket(List<BasketCookieVM> basket, Product product)
        {
            BasketCookieVM existProduct = basket.Find(m => m.Id == product.Id);

            if(existProduct == null)
            {
                basket.Add(new BasketCookieVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Image = product.ProductImages.FirstOrDefault().Image,
                    Count = 1
                });
            }
            else
            {
                existProduct.Count++;
            }

            return existProduct;
        }

    };
}
