using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly IProductService productService;
        private readonly ICommentService commentService;

        public ProductDetailController(IProductService productService,
                                        ICommentService commentService)
        {
            this.productService = productService;
            this.commentService = commentService;
        }
        public async Task<IActionResult> Index(int productId)
        {
            ProductVM productVM = new(await productService.GetProductWithIdAsync(productId))
            {
                Product = await productService.GetProductWithIdAsync(productId),
                Products = await productService.GetProductsAsync(),
                Comments = await commentService.GetSpecialProductCommentsAsync(productId)
            };
            return View(productVM);
        }


        [HttpPost]
        public async Task<BasketCookieVM> AddBasket(int? productId,int productCount)
        {
            if (productId is null) BadRequest();

            if (productCount < 1)
            {
                productCount = 1;
            }

            Product product = await productService.GetProductWithIdAsync((int)productId);

            List<BasketCookieVM> basket = GetBasket();

            UpdateBasket(basket, product,productCount);

            //await UpdateBasketDatas(basket);

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));

            return UpdateBasket(basket,product,productCount);
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

        public BasketCookieVM UpdateBasket(List<BasketCookieVM> basket, Product product,int productCount)
        {
            BasketCookieVM existProduct = basket.Find(m => m.Id == product.Id);

            if (product.Discount < 1)
            {
                product.Discount = 1;
            }

            if(existProduct == null)
            {
                basket.Add(new BasketCookieVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Image = product.ProductImages.FirstOrDefault().Image,
                    Price = product.RealPrice *(100 - product.Discount)/ 100,
                    Count = productCount
                }) ;
            }
            else
            {
                existProduct.Count = productCount;
            };

            return existProduct;
        }


        [HttpPost]
        public List<BasketCookieVM> RemoveProduct(int productId)
        {
            List<BasketCookieVM> basketCookies = JsonConvert.DeserializeObject<List<BasketCookieVM>>(Request.Cookies["basket"]);

            BasketCookieVM productRemove = basketCookies.Find(m=>m.Id == productId);

            basketCookies.Remove(productRemove);

            Response.Cookies.Append("basket", JsonConvert.SerializeObject(basketCookies));

            return basketCookies;

        }

        [HttpPost]
        public async Task AddComment(int productId, string name, string comment)
        {
            await commentService.PostCommentAsync(productId, name, comment);
        }

    }}
