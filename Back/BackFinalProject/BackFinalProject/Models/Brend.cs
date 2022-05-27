using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class Brend : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public string Text { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
