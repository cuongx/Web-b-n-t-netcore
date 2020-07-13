using Casetudy.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel
{
    public class ViewModel: Employees
    {
        public string CarName { get; set; }
         
     public string Search { get; set; }

    }
}
