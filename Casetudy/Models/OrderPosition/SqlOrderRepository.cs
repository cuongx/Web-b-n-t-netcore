using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Models
{
    public class SqlOrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public SqlOrderRepository(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
             this.context = context;
            this.userManager = userManager;
        }

        public Order Create(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
            return order;
        }

        public bool Delete(string id)
        {
           var emp =  context.Orders.Find(id);
            if(emp != null)
            {
                context.Orders.Remove(emp);
                return context.SaveChanges()> 0;
            }
            return false;
        }

        public Order Edit(Order order)
        {
            var emp = context.Orders.Attach(order);
            emp.State = EntityState.Modified;
            context.SaveChanges();
            return order;
        }

        public IEnumerable<Order> Get()
        {
            return context.Orders;
        }

        public Order Gets(string id)
        {
            //var data = (from o in context.Orders
            //            join e in context.Employees                      
            //             on o.EmployeeId equals e.Id
            //            where o.OrderId == id
            //            select new OrderEmployeesViewsModel()
            //            {
            //                Avatar = e.AvatarPath,
            //                CarColor = o.CarColor,
            //                Carname = o.Carname,
            //                EmployeeId = e.Id,
            //                OrderId = o.OrderId,
            //                OrderName = o.OrderName,
            //                Date = o.Date,
            //                City = o.City,
            //                Phone = o.Phone,

            //            }).ToList();
            return context.Orders.Find(id);
        }

    
    }
}
