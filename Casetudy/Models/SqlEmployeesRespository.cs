using Case.Models;
using Casetudy.Models.ListAvatar;
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
                Price = employees.Price,
                Color = employees.Color,
                Yeard = employees.Yeard,
                Register = employees.Register
            };
            if (employees.Gallery != null)
            {
                empl.Gallerys = new List<Gallery>();
                foreach (var file in employees.Gallery)
                {
                    empl.Gallerys.Add(new Gallery()
                    {
                        Name = file.Name,
                        Url = file.Url
                    });
                }
            }
            context.Employees.AddRange(empl);
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

            return employees ;

        }

        public bool Delete(int id)
        {
            ///Xóa bảng nối
            var emp = context.Employees.Find(id);

            if (emp != null)
            {
                List<EmployeeDescription> elist = (from de in context.EmployeeDescriptions
                                                   where de.DescriptionId == emp.Id
                                                   select de).ToList();
                context.EmployeeDescriptions.RemoveRange(elist);
                context.SaveChanges();
                context.Employees.Remove(emp);
                return context.SaveChanges() > 0;

            }
            return false;

        }

        public EditEmployeeViewsModel Edit(EditEmployeeViewsModel employees)
        {
            List<EmployeeDescription> elist =
                (from de in context.EmployeeDescriptions where de.EmployeeId == employees.EmployeeId select de).ToList();
            context.EmployeeDescriptions.RemoveRange(elist);
            context.SaveChanges();
            if (employees.Descriptions != null)
            {
                IEnumerable<EmployeeDescription> descriptions = employees.Descriptions.Select(a => new EmployeeDescription()
                {
                    DescriptionId = a,
                    EmployeeId = employees.EmployeeId
                });
                context.AddRange(descriptions);
                context.SaveChanges();
            }

            if (employees.Gallery != null)
            {
                //List<Gallery> galleries = (from g in context.Gallerys where g.EmployeeId == employees.EmployeeId select g).ToList();
                List<Gallery> galleries = employees.Gallery.Select(a => new Gallery()
                {
                    Id = a.Id,
                    EmployeeId = employees.EmployeeId,
                    Name = a.Name,
                    Url = a.Url
                }).ToList();
                context.AddRange(galleries);
                context.SaveChanges();

                //foreach (var iteam in employees.Gallery)
                //{
                //    emp.Entity.Add(new Gallery()
                //    {
                //        Id = iteam.Id,
                //        Name = iteam.Name,
                //        Url = iteam.Url
                //    });

                //}
            }
  
            var emp = context.Employees.Attach(new Employees()
            {
                AvatarPath = employees.AvatarPath,
                CarbrandId = employees.CarbrandId,
                Id = employees.EmployeeId,
                Name = employees.Name,
                Price = employees.Price,
                Color = employees.Color,
                Register = employees.Register,
                Yeard = employees.Yeard

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
                            Price = e.Price,
                            Color = e.Color,
                            Register = e.Register,
                            Yeard = e.Yeard,
                            Gallery = e.Gallerys.Select(a => new GalleryModel()
                            {
                                Id = a.Id,
                                Name = a.Name,
                                Url = a.Url
                            }).ToList()

                        }).FirstOrDefault();
            //var gallerys = (from g in context.Gallerys join e in context.Employees on g.EmployeeId equals e.Id where g.EmployeeId == data.Id select g).ToList();
            var description = (from d in context.Descriptions
                               join dl in context.EmployeeDescriptions on
                             d.DescriptionId equals dl.DescriptionId
                               where dl.EmployeeId == data.Id
                               select d).ToList();
            data.Descriptions = description;
            return data;
            //return context.Employees.Where(a => a.Id == id).Select(employee => new EmployeeDetailsViewsModel()
            //{
            //    Name = employee.Name,
            //    Color = employee.Color,
            //    Id = employee.Id,
            //    Yeard = employee.Yeard,
            //    Register = employee.Register,
            //    Gallery = employee.Gallerys.Select(b => new GalleryModel()
            //    {
            //        Id = b.Id,
            //        Name = b.Name,
            //        Url = b.Url
            //    }).ToList()
            //}).FirstOrDefault();

        }
    };
}
      
    

