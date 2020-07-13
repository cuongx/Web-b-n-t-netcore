using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel.Order
{
    public class OrderViewsModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        [StringLength(100)]
        public string City { get; set; }

        public string Carbrand { get; set; }
        [Phone]
        public string Phone { get; set; }
      

    }
}
