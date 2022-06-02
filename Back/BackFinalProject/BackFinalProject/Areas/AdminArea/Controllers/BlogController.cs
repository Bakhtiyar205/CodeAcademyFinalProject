using BackFinalProject.Datas;
using BackFinalProject.Models;
using BackFinalProject.Services.Interfaces;
using BackFinalProject.Utilities.Files;
using BackFinalProject.Utilities.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
                if (blogSpesification.BlogText.Length > 500)
                {
                    ModelState.AddModelError(nameof(blogSpesification.BlogText), "Characters should be less than 300");
                    return View(blog);
                }
                if (blogSpesification.Photo == null)
                {
                    ModelState.AddModelError(nameof(blogSpesification.Photo), "Please Upload New Photo");
                    return View(blog);
                }
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
            Blog blogId = await context.Blogs.OrderByDescending(m => m.Id).FirstOrDefaultAsync();

            foreach (var blogSpesification in blog.BlogSpesifications)
            {
                string fileName = Guid.NewGuid().ToString() + "_" + blogSpesification.Photo.FileName.Substring(blogSpesification.Photo.FileName.IndexOf("."));

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

        public async Task<IActionResult> Edit(int Id, int? blogSpecificationId, int? blogSpecRow)
        {

            Blog blog = await blogService.GetBlogAsync(Id);

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
                    { });
                }
            }

            ViewBag.blogSpecRow = blogSpecRow;

            ViewBag.SelectList = await GetSelectList();

            if (blogSpecificationId != null)
            {
                if (blogSpecificationId != 0)
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
        public async Task<IActionResult> Edit(int Id, Blog blog)
        {
            if (!ModelState.IsValid) return View(blog);
            if (blog.BlogSpesifications != null)
            {
                foreach (var blogDetails in blog.BlogSpesifications)
                {
                    if(blogDetails.BlogText != null)
                    {
                        if (blogDetails.BlogText.Length > 500)
                        {
                            ModelState.AddModelError(nameof(blogDetails.BlogText), "Characters should be less than 300");
                            return View(blog);
                        }
                    }
                    if (blogDetails.Id == 0)
                    {
                        if (blogDetails.Photo == null)
                        {
                            ModelState.AddModelError(nameof(blogDetails.Photo), "Please Upload New Photo");
                            return View(blog);
                        }
                    }
                    if (blogDetails.Photo != null)
                    {
                        if (!blogDetails.Photo.CheckFileType("image/"))
                        {
                            ModelState.AddModelError("Photo", "Only image type is accebtible");
                            return View(blog);
                        }

                        if (!blogDetails.Photo.CheckFileSize(800))
                        {
                            ModelState.AddModelError("Photo", "Must be Less than 800KB");
                            return View(blog);
                        }
                    }


                }

            }
            Blog dbBlog = await blogService.GetBlogAsync(Id);

            if (dbBlog == null) NotFound();

            ViewBag.SelectList = await GetSelectList();


            dbBlog.Name = blog.Name;
            dbBlog.CategoryId = blog.CategoryId;
            if (blog.BlogSpesifications != null)
            {
                foreach (var blogSpesification in blog.BlogSpesifications)
                {
                    if (blogSpesification.Id != 0)
                    {
                        BlogSpesification blogSpecUpdate = await blogSpecificationService.GetBlogSpecificationAsync(blogSpesification.Id);
                        blogSpecUpdate.BlogText = blogSpesification.BlogText;
                        if (blogSpesification.Photo != null)
                        {
                            string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/blog", blogSpecUpdate.Image);
                            Helper.DeleteFile(path);
                            string fileName = Guid.NewGuid().ToString() + "_" + blogSpesification.Photo.FileName.Substring(blogSpesification.Photo.FileName.IndexOf("."));
                            string newPath = Helper.GetFilePath(environment.WebRootPath, "assets/img/blog", fileName);
                            await blogSpesification.Photo.SaveFiles(newPath);
                            blogSpecUpdate.Image = fileName;
                        }
                    }
                    else if (blogSpesification.Id == 0)
                    {
                        if (blogSpesification != null)
                        {
                            BlogSpesification blogSpecCreate = new()
                            {
                                BlogId = dbBlog.Id,
                                Blog = dbBlog

                            };
                            if (blogSpesification.BlogText != null)
                            {
                                blogSpecCreate.BlogText = blogSpesification.BlogText;
                            }
                            else
                            {
                                blogSpecCreate.BlogText = " ";
                            }
                            if (blogSpesification.Photo != null)
                            {
                                string fileName = Guid.NewGuid().ToString() + "_" + blogSpesification.Photo.FileName.Substring(blogSpesification.Photo.FileName.IndexOf("."));
                                string path = Helper.GetFilePath(environment.WebRootPath, "assets/img/blog", fileName);
                                await blogSpesification.Photo.SaveFiles(path);
                                blogSpecCreate.Image = fileName;
                            }


                            await context.BlogSpesifications.AddAsync(blogSpecCreate);
                        }

                    }
                }

            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int id)
        {
            Blog blog = await blogService.GetBlogAsync(id);
            if (blog is null) return NotFound();
            ViewBag.GetSelectList = GetSelectList();
            return View(blog);
        }

        public async Task<IActionResult> Delete(int id)
        {
            Blog blog = await blogService.GetBlogAsync(id);
            if (blog is null) return NotFound();
            blog.IsDeleted = true;
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<SelectList> GetSelectList()
        {
            var categories = await context.Categories.Where(m => !m.İsDeleted).ToListAsync();
            return new SelectList(categories, "Id", "Name");
        }
    }
}
