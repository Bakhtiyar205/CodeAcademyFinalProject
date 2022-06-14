using BackFinalProject.Services.Interfaces;
using BackFinalProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;
        private readonly ICategoryService categoryService;

        public BlogController(IBlogService blogService,
                                ICategoryService categoryService)
        {
            this.blogService = blogService;
            this.categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            int wishListCount = 0;
            if (Request.Cookies["wishList"] != null)
            {
                wishListCount = JsonConvert.DeserializeObject<List<WishListVM>>(Request.Cookies["wishList"]).Count();
            }
            BlogsVM blogsVM = new()
            {
                Blogs = await blogService.GetBlogsAsync(),
                Categories = await categoryService.GetCategoriesAsync(),
                WishListCount = wishListCount
            };
            return View(blogsVM);
        }

        public async Task<IActionResult> BlogDetail(int blogId)
        {
            BlogVM blogVM = new()
            {
                Blog = await blogService.GetBlogAsync(blogId)
            };
            return View(blogVM);
        }

        public async Task<IActionResult> BlogWithCategory(int categoryId)
        {
            BlogWithCategoryVM blogWithCategoryVM = new()
            {
                Blogs = await blogService.GetBlogWithCategoryAsync(categoryId),
                Categories = await categoryService.GetCategoriesAsync(),
                Category = await categoryService.GetCategoriesWithIdAsync(categoryId)
            };
            return View(blogWithCategoryVM);
        }
    }
}
