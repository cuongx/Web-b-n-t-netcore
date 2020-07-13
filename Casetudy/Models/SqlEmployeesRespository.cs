using Case.Models;
using Casetudy.Views.ViewsModel;
using Casetudy.Views.ViewsModel.Order;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace Casetudy.Models
{
    public class SqlEmployeesRespository : IEmployeesRepository
    {
        private readonly AppDbContext context;
          
        public SqlEmployeesRespository(AppDbContext context)
        {
            this.context = context;
        }

        public CreateEmployeeViewsModel Create(CreateEmployeeViewsModel employees)
        {
            ///Craete new Employyee
            var empl = new Employees()
            {
                Name = employees.Name,
                AvatarPath = employees.AvatarPath,
                CarbrandId = employees.CarbrandId,
                Price = employees.Price
            };
            context.Employees.Add(empl);
            context.SaveChanges();

            ///Check if Description !=null create new DescriptionEmployee
            if (employees.Descriptions != null)
            {
            
              IEnumerable<EmployeeDescription> elist = employees.Descriptions.Select(a => new EmployeeDescription()
                {
                   DescriptionId = a,
                   EmployeeId = empl.Id
                }).ToList();
                  context.EmployeeDescriptions.AddRange(elist);
                   context.SaveChanges();
            }
            employees.EmployId = empl.Id;
            return employees;
            
        }

        public bool Delete(int id)
        {
            ///Xóa bảng nối
            var emp = context.Employees.Find(id);
            
            if(emp != null)
            {
                List<EmployeeDescription> elist = (from de in context.EmployeeDescriptions
                                                   where de.DescriptionId == emp.Id
                                                   select de).ToList();
                context.EmployeeDescriptions.RemoveRange(elist);
                context.SaveChanges();
                context.Employees.Remove(emp);
                return context.SaveChanges()>0;
            
            }
            return false;
          
        }

        public EditEmployeeViewsModel Edit(EditEmployeeViewsModel employees)
        {
            List<EmployeeDescription> elist = 
                (from de in context.EmployeeDescriptions where de.EmployeeId == employees.EmployeeId select de).ToList();
            context.EmployeeDescriptions.RemoveRange(elist);
            context.SaveChanges();
            if(employees.Descriptions != null)
            {
                IEnumerable<EmployeeDescription> descriptions = employees.Descriptions.Select(a => new EmployeeDescription()
                {
                    DescriptionId = a,
                    EmployeeId = employees.EmployeeId
                });
                context.AddRange(descriptions);
                context.SaveChanges();
            }
            var emp = context.Employees.Attach(new Employees() { 
            
            AvatarPath =employees.AvatarPath,
            CarbrandId = employees.CarbrandId,
            Id = employees.EmployeeId,
            Name = employees.Name,
            Price =employees.Price
            });
            emp.State = EntityState.Modified;
            context.SaveChanges();
            return employees;
        }

      
        public IEnumerable<Employees> Get()
        {
            return context.Employees;
        }

        public EmployeeDetailsViewsModel Gets(int id)
        {
            var data = (from e in context.Employees
                        join d in context.Carbrands
                        on e.CarbrandId equals
                        d.CarbrandId
                        where e.Id == id
                        select new EmployeeDetailsViewsModel()
                        {
                            Id = e.Id,
                            CarbrandId = d.CarbrandId,
                            AvartarPath = e.AvatarPath,
                            CarbrandName = d.CarbrandName,
                            Name = e.Name,
                            Price = e.Price

                        }).FirstOrDefault();
            var description = (from d in context.Descriptions join
                               dl in context.EmployeeDescriptions on
                               d.DescriptionId equals dl.DescriptionId                      
                               where dl.EmployeeId == data.Id 
                               select d).ToList();
            data.Descriptions = description;
            return data;
        }

      
    }
      
    }

