using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Models
{
    public class EditEmployeeViewsModel
    {
        public int EmployeeId { get; set; }
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
