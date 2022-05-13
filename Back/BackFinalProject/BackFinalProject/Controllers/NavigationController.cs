using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class NavigationController : Controller
    {
        private readonly IBlogService blogService;
        private readonly IPolicyService policyService;
        private readonly IDiscountCategoryService discountCategoryService;
        private readonly IBestOfferService bestOfferService;

        public NavigationController(IBlogService blogService,
                                     IPolicyService policyService,
                                     IDiscountCategoryService discountCategoryService,
                                     IBestOfferService bestOfferService)
        {
            this.blogService = blogService;
            this.policyService = policyService;
            this.discountCategoryService = discountCategoryService;
            this.bestOfferService = bestOfferService;
        }
        public async Task<IActionResult> Question()
        {
            return View();
        }

        public async Task<IActionResult> Catalog()
        {
            return View();
        }

        public async Task<IActionResult> Store()
        {
            return View();
        }

        public async Task<IActionResult> Policy()
        {
            PolicyVM policyVM = new()
            {
                Policies = await policyService.GetPoliciesAsync()
            };
            return View(policyVM);
        }

        public async Task<IActionResult> Blog(int blogId)
        {
            BlogVM blogVM = new()
            {
                Blog = await blogService.GetBlogAsync(blogId)
            };
            return View(blogVM);
        }

        public async Task<IActionResult> DiscountCategory()
        {
            DiscountCategoryVM discountCategoryVM = new()
            {
                DiscountCategroy = await discountCategoryService.GetDiscountCategroyAsync()
            };
            return View(discountCategoryVM);
        }

        public async Task<IActionResult> BestOffer()
        {
            BestOfferVM bestOfferVM = new()
            {
                BestOffer = await bestOfferService.GetBestOfferAsync()
            };
            return View(bestOfferVM);
        }
    }
}
