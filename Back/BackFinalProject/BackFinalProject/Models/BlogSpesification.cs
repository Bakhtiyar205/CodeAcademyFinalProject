using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class BlogSpesification:BaseEntity
    { 
        [Required]
        [DataType(DataType.Text)]
        public string Image { get; set; }
        public string BlogText { get; set; }
        public bool IsDeleted { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
