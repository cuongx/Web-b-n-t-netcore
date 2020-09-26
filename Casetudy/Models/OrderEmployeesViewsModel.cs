using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Models
{
    public class OrderEmployeesViewsModel
    {
        public string OrderId { get; set; }

        [Required]
        [MaxLength(100)]
        public string OrderName { get; set; }

        public Employees Employees { get; set; }
        public int EmployeeId { get; set; }

        [StringLength(100)]
        public DateTime Date { get; set; }

        public string City { get; set; }


        [Phone]
        public string Phone { get; set; }
        [StringLength(100)]
        public string Carname { get; set; }
        public string Avatar { get; set; }
        public string CarColor { get; set; }
   
        //public List<Employees> Employees { get; set; }
    }
}
