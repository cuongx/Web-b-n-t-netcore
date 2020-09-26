using Case.Models;
using Casetudy.Models.ListAvatar;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Models
{
    public class Employees
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage ="Nhập lại số tiền")]
        //[DataType(DataType.Currency)]
        public float Price { get; set; }
        public string AvatarPath { get; set; }
        public Carbrand Carbrand { get; set; }
        public int CarbrandId { get; set; }
        public int Yeard { get; set; }
        public int Register { get; set; }
        public string Color { get; set; }
        public ICollection<EmployeeDescription> EmployeeDescriptions { get; set; }
        public ICollection<Gallery> Gallerys { get; set; }

        }


    }

