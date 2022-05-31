using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class BestOffer:BaseEntity
    {
        [DataType(DataType.Text), MaxLength(400), MinLength(10)]
        [Required]
        public string Text { get; set; }
        public List<BestOfferImages> Images { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        [NotMapped]
        public List<IFormFile> Photo { get; set; }
    }
}
