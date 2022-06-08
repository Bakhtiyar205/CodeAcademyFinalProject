using BackFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Areas.AdminArea.ViewModels
{
    public class CommentVM
    {
        public Comment Comment { get; set; }
        public Product Product { get; set; }
    }
}
