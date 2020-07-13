using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Models
{
    public class CarbandRepository : ICarbrandRepository
    {
        private readonly AppDbContext contexts;

        public CarbandRepository(AppDbContext contexts)
        {
            this.contexts = contexts;
        }

        public Carbrand Create(Carbrand carbrand)
        {
            contexts.Carbrands.Add(carbrand);
            contexts.SaveChanges();
            return carbrand;
        }

   

        public bool Delete(int id)
        {
            var car = contexts.Carbrands.Find(id);
            if(car != null)
            {
                contexts.Carbrands.Remove(car);
                return contexts.SaveChanges() > 0;
            }
            return false;
        }

        public Carbrand Edit(Carbrand carbrand)
        {

            var empl = contexts.Carbrands.Attach(carbrand);
            empl.State = EntityState.Modified;
            contexts.SaveChanges();
            return carbrand;                      
        }


        public Carbrand Gets(int id)
        {

            return contexts.Carbrands.Find(id);
        }

        public IEnumerable<Carbrand> Get()
        {
            return contexts.Carbrands;
        }
    }
}
