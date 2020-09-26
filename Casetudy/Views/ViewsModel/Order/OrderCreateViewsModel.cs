using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel.Order
{
    public class OrderCreateViewsModel
    {
        public string OrderId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }       
        public DateTime Date { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Carbrand { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [StringLength(100)]
        public string CarName { get; set; }
        [Required]
        public string Avatar { get; set; }
        [Required]
        public string Color { get; set; }
    }
}
