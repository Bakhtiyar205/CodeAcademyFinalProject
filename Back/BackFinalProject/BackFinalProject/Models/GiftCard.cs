using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class GiftCard:BaseEntity
    {
        [Required]
        [DataType(DataType.Text),MaxLength(100)]
        public string Name { get; set; }
        [DataType(DataType.Text), MaxLength(50)]
        public string Image { get; set; }
        [Required]
        [NotMapped]
        public IFormFile Photo { get; set; }
        public bool IsDeleted { get; set; }
    }
}
