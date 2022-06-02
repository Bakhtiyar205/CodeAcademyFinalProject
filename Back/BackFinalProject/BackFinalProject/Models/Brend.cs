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
        [Required]
        [DataType(DataType.Text),MaxLength(100)]
        public string Name { get; set; }
        [DataType(DataType.Text), MaxLength(50)]
        public string Image { get; set; }
        [DataType(DataType.Text), MaxLength(1000)]
        public string Text { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
