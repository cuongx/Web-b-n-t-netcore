using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel
{
    public class UserViewsModel
    { 
        public string UserID { get; set; }
        [Required]
        public string RoleName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
     

    }
}
