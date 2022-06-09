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
    public class WishListController : Controller
    {
        private readonly IProductService productService;

        public WishListController(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            List<WishListDetailVM> wishListDetail = new();
            if(Request.Cookies["wishList"] != null)
            {
                List<WishListVM> wishLists = JsonConvert.DeserializeObject<List<WishListVM>>(Request.Cookies["wishList"]);

                foreach (WishListVM wishListProduct in wishLists)
                {
                    Product product = await productService.GetProductWithIdAsync(wishListProduct.Id);

                    WishListDetailVM wishListProductDetail = new()
                    {
                        Product = product
                    };

                    wishListDetail.Add(wishListProductDetail);
                }
            }
            return View(wishListDetail);
        }

        [HttpPost]
        public async Task<WishListVM> AddWishList(int? productId)
        {
            if (productId is null) BadRequest();
            Product product = await productService.GetProductWithIdAsync((int)productId);
            List<WishListVM> wishList = GetWishList();
            UpdateWishList(wishList, product);
            Response.Cookies.Append("wishList", JsonConvert.SerializeObject(wishList));
            return UpdateWishList(wishList, product);
        }

        private List<WishListVM> GetWishList()
        {
            List<WishListVM> wishList;
            if(Request.Cookies["wishList"] != null)
            {
                wishList = JsonConvert.DeserializeObject<List<WishListVM>>(Request.Cookies["wishList"]);
            }
            else
            {
                wishList = new List<WishListVM>();
            }
            return wishList;
        }

        private WishListVM UpdateWishList(List<WishListVM> wishList, Product product)
        {
            WishListVM existWishListProduct = wishList.Find(m => m.Id == product.Id);
            if(existWishListProduct == null)
            {
                wishList.Add(new WishListVM
                {
                    Id= product.Id,
                    Name = product.Name,
                    Image = product.ProductImages.FirstOrDefault()?.Image,
                    Price = product.RealPrice*(100-product.Discount)/100,
                });
            }

            return existWishListProduct;
        }

        [HttpPost]
        public List<WishListVM> RemoveProduct(int productId)
        {
            List<WishListVM> wishListCookies = JsonConvert.DeserializeObject<List<WishListVM>>(Request.Cookies["wishList"]);

            WishListVM productRemove = wishListCookies.Find(m => m.Id == productId);

            wishListCookies.Remove(productRemove);

            Response.Cookies.Append("wishList", JsonConvert.SerializeObject(wishListCookies));

            return wishListCookies;

        }
    }
}
