using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DEXAGROUP.Models
{
    public class AppUser : IdentityUser
    {
        //[Required]
        [Display(Name = "Full Name")]
        [StringLength(50, ErrorMessage = "{0} cannot be less than {2} and more than {1} characters !", MinimumLength = 3)]
        public string FullName { get; set; }
    }
}
