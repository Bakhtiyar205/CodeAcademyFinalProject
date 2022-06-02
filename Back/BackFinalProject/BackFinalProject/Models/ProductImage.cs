using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class ProductImage:BaseEntity
    {
        [DataType(DataType.Text),MaxLength(70)]
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [NotMapped]
        public IFormFile FormPhoto { get; set; }
    }
}
