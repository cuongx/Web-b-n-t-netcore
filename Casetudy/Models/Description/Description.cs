using Case.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Models
{
    public class Description
    {
        [Required]
        public int DescriptionId { get; set; }

        [Required]
        [MaxLength(50)]

        public string OriginName { get; set; }

        public ICollection<EmployeeDescription> EmployeeDescriptions { get; set; }
    }
}
