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
        public decimal Discount { get; set; }
        [Required]
        public decimal RealPrice { get; set; }
        public bool IsOnline { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsOutlet { get; set; }
        public int SubCategoryId { get; set; }
        [Required]
        public List<IFormFile> Photos { get; set; }
    }
}
