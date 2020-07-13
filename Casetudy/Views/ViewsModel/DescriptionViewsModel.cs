using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel
{
    public class DescriptionViewsModel
    {
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
       
    }
}
