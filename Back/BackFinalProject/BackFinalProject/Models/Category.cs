using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public bool İsDeleted { get; set; }
        public string Image { get; set; }
        public string CategoryText { get; set; }
        public List<SubCategory> SubCategory { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<DiscountCategroy> DiscountCategroies { get; set; }
    }
}
