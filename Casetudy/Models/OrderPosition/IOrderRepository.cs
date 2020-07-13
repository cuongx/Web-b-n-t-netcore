using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Models
{
  public  interface IOrderRepository
    {
        IEnumerable<Order> Get();
        Order Gets(int id);
        Order Edit(Order order);
        Order Create(Order order);
        bool Delete(int id);
    }
}
