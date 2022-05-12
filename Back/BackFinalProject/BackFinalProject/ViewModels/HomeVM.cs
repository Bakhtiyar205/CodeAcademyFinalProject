using BackFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.ViewModels
{
    public class HomeVM
    {
        public List<Category> Categories { get; set; }
        public Dictionary<string,string> Setting { get; set; }
        public List<Brend> Brends { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
