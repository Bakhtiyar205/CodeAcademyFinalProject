using BackFinalProject.Utilities.Validators;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Areas.AdminArea.ViewModels
{
    public class ProductCreateVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Detail { get; set; }
        [Required]
        [MaxValue(maxValue: 100, ErrorMessage = "MaxValue should be less than or equal to 100")]
        [MinValue(minValue: 0, ErrorMessage = "MinValue should be higher than or equal to 0")]
        public decimal Discount { get; set; }
        [Required]
        [MaxValue(maxValue:10000, ErrorMessage = "MaxValue should be less than or equal to 10000")]
        [MinValue(minValue: 0, ErrorMessage = "MinValue should be higher than or equal to 0")]
        public decimal RealPrice { get; set; }
        public bool IsOnline { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsOutlet { get; set; }
        public int SubCategoryId { get; set; }
        [Required]
        public List<IFormFile> Photos { get; set; }
    }
}
