using BackFinalProject.Utilities.Validators;
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
        [MaxValue(maxValue: 100, ErrorMessage = "MaxValue should be less than 100")]
        [MinValue(minValue: 0, ErrorMessage = "MinValue should be higher than or equal to 0")]
        public decimal Discount { get; set; }
        [MaxValue(maxValue: 10000, ErrorMessage = "MaxValue should be less than 10000")]
        [MinValue(minValue: 0, ErrorMessage = "MinValue should be higher than or equal to 0")]
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
