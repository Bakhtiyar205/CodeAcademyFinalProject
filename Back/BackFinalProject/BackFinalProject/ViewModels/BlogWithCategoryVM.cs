using BackFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.ViewModels
{
    public class BlogWithCategoryVM
    {
        public List<Category> Categories { get; set; }
        public List<Blog> Blogs { get; set; }
        public Category Category { get; set; }

    }
}
