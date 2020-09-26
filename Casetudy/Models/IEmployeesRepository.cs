using Casetudy.Views.ViewsModel;
using Casetudy.Views.ViewsModel.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Models
{
  public interface IEmployeesRepository
    {
        //IEnumerable<Employees> Search(string key);
       IEnumerable<Employees> Get();
       EmployeeDetailsViewsModel Gets(int id);
        CreateEmployeeViewsModel Create(CreateEmployeeViewsModel employees);
        EditEmployeeViewsModel Edit(EditEmployeeViewsModel employees);
        bool Delete(int id);
      
    }
}
