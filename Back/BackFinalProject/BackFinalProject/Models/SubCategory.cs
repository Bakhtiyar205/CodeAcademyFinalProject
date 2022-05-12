using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string SubCategoryText { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
