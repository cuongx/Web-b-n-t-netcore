using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel
{
    public class RoleCreateViewsModel
    {
        [Key]
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string Action { get; set; }
    }
}
