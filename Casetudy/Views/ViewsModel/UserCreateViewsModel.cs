using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel
{
    public class UserCreateViewsModel
    {
        [Required]
        [Display(Name ="Role")]
        public string RoleId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }     
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Cofirm password not match")]
        public string CofimPassword { get; set; }

     
    }
}
