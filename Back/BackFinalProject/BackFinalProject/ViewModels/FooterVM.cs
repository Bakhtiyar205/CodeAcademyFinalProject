using BackFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.ViewModels
{
    public class FooterVM
    {
        public Dictionary<string, string> Settings { get; set; }
        public List<Category> Categories { get; set; }
    }
}
