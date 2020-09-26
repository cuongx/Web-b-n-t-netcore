using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel
{
    public class CarbrandCreateVieswModel
    {
         [Required]
        public string Name { get; set; }
       public IFormFile AvatarPath { get; set; }
    
    }
}
