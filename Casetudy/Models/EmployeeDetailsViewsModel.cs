using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Models
{
    public class EmployeeDetailsViewsModel
    {
        public int Id { get; set; }

        public string Name { get; set; }   

        public float Price { get; set; }

        public int CarbrandId { get; set; }

        public string CarbrandName { get; set; }

        public string AvartarPath { get; set; }
        public List<Description> Descriptions { get; set; }
    }
}
