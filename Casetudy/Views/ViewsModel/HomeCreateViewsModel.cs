using Casetudy.Models;
using Casetudy.Models.ListAvatar;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel
{
    public class HomeCreateViewsModel
    {
        public int EmployeeId { get; set; }
        [Required]
        public IFormFile Avatar { get; set; }

        [Required]
        public string Name { get; set;}
        [Required]
        public int CarbrandId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float Price { get; set; }
        [Display(Name = "Year Production")]
        [Required(ErrorMessage ="Bạn vui lòng nhập năm sản xuất")]
        public int Yeard { get; set; }
        [Display(Name ="Year Register")]
        [Required(ErrorMessage ="Bạn vui lòng nhập năm đăng kí")]
        public int Register { get; set; }
        [Display(Name = "Color Car")]
        [Required(ErrorMessage = "Bạn vui lòng chọn màu")]
        public string Color { get; set; }
        [Required]
        public List<int> Descriptions { get; set; }
        public IFormFileCollection GalleryFiles { get; set; }
        public List<GalleryModel> Gallery { get; set; }
    }
}
