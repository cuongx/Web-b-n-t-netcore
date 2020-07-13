using Casetudy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Views.ViewsModel
{
    public class SearchViewsModels
    {
        public IEnumerable<Employees> Employees { get; set; }
        public string SearchKey { get; set; }
    }
}
