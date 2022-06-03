using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.ViewModels
{
    public class LoginVM
    {
        [Required, MaxLength(100)]
        public string UserNameOrEmail { get; set; }
        [Required, DataType(DataType.Password),MaxLength(100)]
        public string Password { get; set; }
    }
}
