using BackFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.ViewModels
{
    public class SubCategoryVM
    {
        public SubCategory SubCategory { get; set; }
        public List<Product> Products { get; set; }
        public int WishListCount { get; set; }
        public List<WishListVM> wishListVM { get; set; }
    }
}
