using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Models
{
    public class Order
    {
        [Key]
        public string OrderId { get; set; }

        [Required]
        [MaxLength(100)]
        public string OrderName { get; set; }

        public Employees Employees { get; set; }
        //public int EmployeeId { get; set; }

        [StringLength(100)]
        public DateTime Date { get; set; }

     
        public string City { get; set; }
    
        //public string Carbrand { get; set; }
        [Phone]
        public string Phone { get; set; }
        [StringLength(100)]
   
        public string Carname { get; set; }      
        public string CarColor { get; set; }


    }
}
