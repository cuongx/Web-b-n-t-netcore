using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Casetudy.Models.ListAvatar;

namespace Casetudy.Models.Gallerys
{
   public interface IGallerysRepository
    {
        IEnumerable<Gallery> Gets();
        Gallery Get(int id);
        Gallery Create(Gallery gallery);
        Gallery Edit(Gallery gallery);
        bool Delete(int id);
    }
}
