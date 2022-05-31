using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class Product : BaseEntity
    {
        [Required]
        [DataType(DataType.Text), MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text),MaxLength(255)]
        public string Detail { get; set; }
        public decimal Discount { get; set; }
        public decimal RealPrice { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsOnline { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsOutlet { get; set; }
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public List<ProductImage> ProductImages { get; set; }
    }
}
