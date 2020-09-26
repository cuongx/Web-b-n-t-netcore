using Casetudy.Models.ListAvatar;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Models.Gallerys
{
    public class SqlGallerysRepository:IGallerysRepository
    {
        private readonly AppDbContext context;

       public SqlGallerysRepository(AppDbContext context)
        {
            this.context = context;
        }

        public bool Delete(int id)
        {
            var emp = context.Gallerys.Find(id);
            if (emp != null)
            {
                context.Gallerys.RemoveRange(emp);
                return context.SaveChanges() > 0;
            }
            return false;
        }


        public Gallery Get(int id)
        {
            return context.Gallerys.Find(id);
        }


        public IEnumerable<Gallery> Gets()
        {
            return context.Gallerys.ToList();
        }

        public Gallery Edit(Gallery gallery)
        {
            var empl = context.Gallerys.Attach(gallery);
            empl.State = EntityState.Modified;
            context.SaveChanges();
            return gallery;
        }

        public Gallery Create(Gallery gallery)
        {
            context.Gallerys.Add(gallery);
            context.SaveChanges();
            return gallery;
        }


    }
}


