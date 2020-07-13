using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel
{
    public class LamBoViewsModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Nhập lại số tiền")]
        [DataType(DataType.Currency)]
        public float Price { get; set; }
        public string AvatarPath { get; set; }
        public int CarbrandId { get; set; }
    }
}
