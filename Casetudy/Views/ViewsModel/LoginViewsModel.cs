using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel
{
    public class LoginViewsModel
    {
        [Required]
        [EmailAddress]
        //[Compare("Email",ErrorMessage ="The Email Adresses do not match.")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Password Adresses do not match.")]
        public string Password { get; set; }
    
        public bool Remember { get; set; }
        public string ReturnUrl { get; set; }
    }
}
