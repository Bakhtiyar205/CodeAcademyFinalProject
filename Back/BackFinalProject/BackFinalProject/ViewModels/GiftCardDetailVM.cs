using BackFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.ViewModels
{
    public class GiftCardDetailVM
    {
        public List<Category> Categories { get; set; }
        public GiftCard GiftCard { get; set; }
    }
}
