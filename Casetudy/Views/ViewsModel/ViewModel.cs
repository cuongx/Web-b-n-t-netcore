using Case.Models;
using Casetudy.Models;
using Casetudy.Models.ListAvatar;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel
{
    public class ViewModel
    {
        public int Id { get; set; }
        public SelectListItem Emps { get; set; }
        public string Name { get; set; }
        [Required(ErrorMessage = "Nhập lại số tiền")]
        //[DataType(DataType.Currency)]
        public float Price { get; set; }
        public string AvatarPath { get; set; }
        public int CarbrandId { get; set; }
        public int Yeard { get; set; }
        public int Register { get; set; }
        public string Color { get; set; }
        public ICollection<EmployeeDescription> EmployeeDescriptions { get; set; }
         //public IFormFileCollection GalleryFiles { get; set; }
        public List<GalleryModel> Gallery { get; set; }


    }
}
