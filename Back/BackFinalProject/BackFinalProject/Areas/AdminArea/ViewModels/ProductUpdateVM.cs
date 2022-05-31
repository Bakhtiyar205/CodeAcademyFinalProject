using BackFinalProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Areas.AdminArea.ViewModels
{
    public class ProductUpdateVM
    {
        public Product Product { get; set; }
        public List<IFormFile> Photos { get; set; }

    }
}
