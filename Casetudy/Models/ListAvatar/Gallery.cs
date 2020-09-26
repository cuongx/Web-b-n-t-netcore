using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Models.ListAvatar
{
    public class Gallery
    {
        public int Id { get; set; }
      
        public string Name { get; set; }
        public string Url { get; set; }
        public int EmployeeId { get; set; }
        
        public Employees Employee{ get; set; }
  
      
    }
}
