using Microsoft.AspNetCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel
{
    public class RegisterViewsModel
    {
        
        [Required]
        [EmailAddress]
        //[Compare("Email",ErrorMessage ="The Email Adresses do not match.")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
    
        
        public string Password { get; set; }

         [Required]
         [DataType(DataType.Password)]
         [Compare("Password",ErrorMessage ="The password do not Match")]
        [Display(Name = "CofirmPassword")]
        public string CofirmPassword { get; set; }
    }
}
