using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Models
{
    public class BestOffer:BaseEntity
    {
        public string Text { get; set; }
        public List<BestOfferImages> Images { get; set; }
        public bool IsDeleted { get; set; }
    }
}
