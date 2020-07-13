using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel
{
    public class CreateEmployeeViewsModel
    {
        public int EmployId { get; set; }
        public string AvatarPath { get; set; }

        [Required]
        public string Name { get; set; }
        public int CarbrandId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float Price { get; set; }
 
         public List<int> Descriptions { get; set; }
    }
}
