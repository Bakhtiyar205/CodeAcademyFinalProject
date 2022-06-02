using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class PolicySection:BaseEntity
    {
        [Required]
        [DataType(DataType.Text), MaxLength(100)]
        public string Name { get; set; }
        [DataType(DataType.Text), MaxLength(700)]
        public string Detail { get; set; }
        public bool IsDelete { get; set; }
    }
}
