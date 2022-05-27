using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.Utilities.Files;
using BackFinalProject.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;
        private readonly IBlogSpecificationService blogSpecificationService;
        private readonly IWebHostEnvironment environment;
        private readonly AppDBContext context;

        public BlogController(IBlogService blogService,
                              IBlogSpecificationService blogSpecificationService,
                              IWebHostEnvironment environment,
                              AppDBContext context)
        {
            this.blogService = blogService;
            this.blogSpecificationService = blogSpecificationService;
            this.environment = environment;
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await blogService.GetBlogsAsync();
            return View(blogs);
        }

        public async Task<IActionResult> Create(int? blogSpec)
        {
            if (blogSpec == null)
            {
                blogSpec = 1;
            }
            else
            {
                blogSpec++;
            }
            
            ViewBag.BlogSpec = blogSpec;
            ViewBag.SelectList = await GetSelectList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            ViewBag.SelectList = await GetSelectList();

            foreach (var blogSpesification in blog.BlogSpesifications)
            {
                if (!blogSpesification.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photo", "Only image type is accebtible");
                    return View();
                }

                if (!blogSpesification.Photo.CheckFileSize(500))
                {
                    ModelState.AddModelError("Photo", "Must be Less than 200KB");
                    return View();
                }
            }


            await context.Blogs.AddAsync(blog);
            Blog blogId =  await context.Blogs.OrderByDescending(m=>m.Id).FirstOrDefaultAsync();
            
            foreach (var blogSpesification in blog.BlogSpesifications)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + blogSpesification.Photo.FileName;

                string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/blog", fileName);

                //Using Statement note this
                await blogSpesification.Photo.SaveFiles(path);
                blogSpesification.Blog = blog;
                blogSpesification.BlogId = blog.Id;
                blogSpesification.Image = fileName;
                await context.BlogSpesifications.AddAsync(blogSpesification);
            }
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int blogId, int? blogSpecificationId,int? blogSpecRow)
        {
          
            Blog blog = await blogService.GetBlogAsync(blogId);

            if (blog == null) NotFound();

            if (blogSpecRow == null)
            {
                blogSpecRow = 0;
            }
            else
            {
                blogSpecRow++;
                for (int i = 0; i < blogSpecRow; i++)
                {
                    blog.BlogSpesifications.Add(new BlogSpesification
                    {});
                }
            }

            ViewBag.blogSpecRow = blogSpecRow;

            ViewBag.SelectList = await GetSelectList();

            if (blogSpecificationId != null)
            {
                if(blogSpecificationId != 0)
                {
                    int newBlogSpecificationId = (int)blogSpecificationId;
                    BlogSpesification blogSpesification = await blogSpecificationService.GetBlogSpecificationAsync(newBlogSpecificationId);
                    blogSpesification.IsDeleted = true;
                    context.BlogSpesifications.Update(blogSpesification);
                    await context.SaveChangesAsync();
                    return View(blog);
                }
                else if (blogSpecificationId == 0)
                {
                    blog.BlogSpesifications.Remove(blog.BlogSpesifications.FirstOrDefault(x => x.Id == 0));
                    blogSpecRow--;
                }
            }
            

            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int blogId,Blog blog)
        {
            Blog dbBlog = await blogService.GetBlogAsync(blogId);

            if (blog == null) NotFound();

            ViewBag.SelectList = await GetSelectList();


            return View(dbBlog);
        }
        private async Task<SelectList> GetSelectList()
        {
            var categories = await context.Categories.Where(m => !m.İsDeleted).ToListAsync();
            return new SelectList(categories, "Id", "Name");
        }
    }
}
