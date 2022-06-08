using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class Comment: BaseEntity
    {
        [Required]
        [DataType(DataType.Text),MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Text), MaxLength(200)]
        public string CommentSection { get; set; }
        public bool IsConfirmed { get; set; } = false;
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
