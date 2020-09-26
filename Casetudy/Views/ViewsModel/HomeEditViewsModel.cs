using Casetudy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel
{
    public class HomeEditViewsModel:HomeCreateViewsModel
    {
    
        //public int Id { get; set; }
        [Required]
        public string AvatarPath { get; set; }
        public List<Description> SelectDescriptions { get; set; }

    }
}
