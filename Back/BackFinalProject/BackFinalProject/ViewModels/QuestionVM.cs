using BackFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.ViewModels
{
    public class QuestionVM
    {
        public Dictionary<string,string> Settings { get; set; }
        public List<Product> Products { get; set; }
        public int WishListCount { get; set; }
        public List<WishListVM> WishListVM { get; set; }
    }
}
