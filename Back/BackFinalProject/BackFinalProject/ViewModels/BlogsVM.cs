using BackFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.ViewModels
{
    public class BlogsVM
    {
        public List<Blog> Blogs { get; set; }
        public List<Category> Categories { get; set; }
        public int WishListCount { get; set; }
    }
}
