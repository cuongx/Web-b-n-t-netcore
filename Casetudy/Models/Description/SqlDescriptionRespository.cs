using Casetudy.Views.ViewsModel;
using Casetudy.Views.ViewsModel.Order;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace Casetudy.Models
{
    public class SqlDescriptionRespository : IDescriptionRespository
    {
        private readonly AppDbContext context;

        public SqlDescriptionRespository(AppDbContext context)
        {
            this.context = context;
        }

    
        public bool Delete(int id)
        {
            var emp = context.Descriptions.Find(id);
            if(emp != null)
            {
                context.Descriptions.RemoveRange(emp);
                return context.SaveChanges() > 0;
            }
            return false;
        }
      

        public  Description Gets(int id)
        {
            return context.Descriptions.Find(id);
        }

      
        public IEnumerable<Description> Get()
        {
            return context.Descriptions;
        }
   
        public  Description Edit(Description employees)
        {
           var empl=   context.Descriptions.Attach(employees);
            empl.State = EntityState.Modified;
            context.SaveChanges();
            return employees;
        }

        public Description Create(Description employees)
        {
            context.Descriptions.Add(employees);
            context.SaveChanges();
            return employees;
        }

       
    }
}



        //IEnumerable<Employees>ISearch(string key)
        //{
        //         if(string.IsNullOrEmpty(key))
        //        {
        //         return context.Employees;
        //        }
        //       return context.Employees.Where(a => a.Name.Contains(key));
        //}




    
      
    

