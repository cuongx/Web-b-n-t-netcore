using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel.Order
{
    public class OrderEditViewsModel
    {
        [Required]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        [StringLength(100)]
        [Required]
        public string City { get; set; }
        [Required]
        [StringLength(100)]
        public string CarName { get; set; }
        [Phone]
        public string Phone { get; set; }
        [StringLength(100)]
   
        [Required]
        public string Color { get; set; }
        public string Avatar { get; set; }
    }
}
