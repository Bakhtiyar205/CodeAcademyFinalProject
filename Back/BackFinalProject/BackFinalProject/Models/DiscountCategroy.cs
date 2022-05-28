using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class DiscountCategroy : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string DiscountCategoryText { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
