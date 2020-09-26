using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel
{
    public class CarbrandEditViewsModel:CarbrandCreateVieswModel
    {
        public int Id { get; set; }
        public string Avatar { get; set; }

    }
}
