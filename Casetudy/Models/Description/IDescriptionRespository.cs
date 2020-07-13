using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Models
{
   public interface IDescriptionRespository
    {
        IEnumerable<Description> Get();
        Description Gets(int id);
        Description Create(Description employees);
        Description Edit(Description employees);
        bool Delete(int id);
    }
}
