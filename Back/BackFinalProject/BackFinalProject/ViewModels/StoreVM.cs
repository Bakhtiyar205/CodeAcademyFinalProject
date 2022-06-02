using BackFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.ViewModels
{
    public class StoreVM
    {
        public Dictionary<string,string> Setting { get; set; }
        public List<Product> Products { get; set; }
    }
}
