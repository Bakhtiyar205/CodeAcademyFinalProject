using BackFinalProject.Models;
using BackFinalProject.Utilities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.ViewModels
{
    public class CategoryVM
    {
        public Category Category { get; set; }
        public Paginate<Product> Products { get; set; }
        public int WishListCount { get; set; }
        public List<WishListVM> WishListVM { get; set; }
    }
}
