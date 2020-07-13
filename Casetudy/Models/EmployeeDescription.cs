using Casetudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Case.Models
{
    public class EmployeeDescription
    {
        public  int EmployeeId { get; set; }
        public Employees Employees { get; set; }
        public int DescriptionId { get; set; }
        
        public Description Description { get; set; } 
    }
}
