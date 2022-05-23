using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class Category:BaseEntity
    {
        [Required]
        [DataType(DataType.Text),MaxLength(255)]
        public string Name { get; set; }
        public bool İsDeleted { get; set; }
        [Required]
        [DataType(DataType.Text), MaxLength(255)]
        public string Image { get; set; }
        [Required]
        [DataType(DataType.Text), MaxLength(255)]
        public string CategoryText { get; set; }
        public List<SubCategory> SubCategory { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<DiscountCategroy> DiscountCategroies { get; set; }
        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
    }
}
