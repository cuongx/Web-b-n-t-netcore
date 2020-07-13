using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Models
{
    public interface ICarbrandRepository
    {
        IEnumerable<Carbrand> Get();
        Carbrand Gets(int id);
        Carbrand Edit(Carbrand carbrand);
        Carbrand Create(Carbrand carbrand);
        bool Delete(int id);
    }
}
