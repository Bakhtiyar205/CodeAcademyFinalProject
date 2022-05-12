using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class BlogSpesification:BaseEntity
    {
        public string Image { get; set; }
        public string BlogText { get; set; }
        public bool IsDeleted { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
