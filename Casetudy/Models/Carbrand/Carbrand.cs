using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Models
{
    public class Carbrand
    {
        [Required]
        public int CarbrandId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CarbrandName { get; set; }
        public ICollection<Employees> Employees { get; set; }
    }
}
