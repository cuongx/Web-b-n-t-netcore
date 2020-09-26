using Casetudy.Models.ListAvatar;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Models
{
    public class EditEmployeeViewsModel
    {
        public int EmployeeId { get; set; }
        [Required]
        public string AvatarPath { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int CarbrandId { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public float Price { get; set; }
        [Required]

        public int Yeard { get; set; }
        [Required]
        public int Register { get; set; }
        [Required]
        public string Color { get; set; }
        public List<GalleryModel> Gallery { get; set; }
        [Required]
        public List<int> Descriptions { get; set; }
       
    }
}
