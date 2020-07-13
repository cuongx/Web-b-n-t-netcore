using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel
{
    public class UserEditViewsModel
    {
        public string Id { get; set; }
        public string RoleId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
    }
}
