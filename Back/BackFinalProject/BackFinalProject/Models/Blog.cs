using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class Blog : BaseEntity
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public Category Category { get; set; }
        public List<BlogSpesification> BlogSpesifications { get; set; }
    }
}
