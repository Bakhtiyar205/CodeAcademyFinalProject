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

        public NavigationController(IBlogService blogService,
                                     IPolicyService policyService)
        {
            this.blogService = blogService;
            this.policyService = policyService;
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
    }
}
