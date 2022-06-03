using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackFinalProject.ViewModels
{
    public class ForgetPasswordVM
    {
        [Required, DataType(DataType.EmailAddress), MaxLength(100)]
        public string Email { get; set; }
    }
}
