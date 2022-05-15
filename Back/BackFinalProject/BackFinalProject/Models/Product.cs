using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public decimal Discount { get; set; }
        public decimal RealPrice { get; set; } 
        public DateTime Date { get; set; }
        public bool IsOnline { get; set; }
        public bool IsDeleted { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
