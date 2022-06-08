using BackFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.Areas.AdminArea.ViewModels
{
    public class UsersVM
    {
        public AppUser User { get; set; }
        public bool IsModerator { get; set; }

    }
}
