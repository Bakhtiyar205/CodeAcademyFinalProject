using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class Blog : BaseEntity
    {
        [DataType(DataType.Text),MinLength(5),MaxLength(100)]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Category Category { get; set; }
        public List<BlogSpesification> BlogSpesifications { get; set; }
    }
}
