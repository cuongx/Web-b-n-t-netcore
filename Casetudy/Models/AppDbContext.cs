using Case.Models;
using Casetudy.Models.ListAvatar;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Models
{

    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Gallery> Gallerys { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Carbrand> Carbrands { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<EmployeeDescription> EmployeeDescriptions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                        
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmployeeDescription>().HasKey(ed => new { ed.EmployeeId, ed.DescriptionId });
            modelBuilder.Entity<Employees>().HasData(

                  new Employees()
                  {
                      Id = 1,
                      Name = "FordEverest",
                      CarbrandId = 1,
                      AvatarPath = @"fOR.jpg",
                      Price = 8000000

                  },

                  new Employees()
                  {
                      Id = 2,
                      Name = "Lexus2019",
                      CarbrandId = 2,
                      AvatarPath = @"lAMBO.jpg",
                      Price = 9000000
                  });

            modelBuilder.Entity<Carbrand>().HasData(

                   new Carbrand()
                   {
                       CarbrandId = 1,
                       CarbrandName = "FORD"

                   },
                   new Carbrand()
                   {
                       CarbrandId = 2,
                       CarbrandName = "LEXUS"

                   });

            modelBuilder.Entity<Description>().HasData(

                   new Description()
                   {
                       OriginName = "Anh Quốc",
                       DescriptionId = 1

                   },
                   new Description()
                   {
                       OriginName = "Hoa Kì",
                       DescriptionId = 2
                   }, new Description()
                   {
                       OriginName = "Việt Nam",
                       DescriptionId = 3

                   },
                   new Description()
                   {
                       OriginName = "Italia",
                       DescriptionId = 4
                   });

            modelBuilder.Entity<EmployeeDescription>().HasData(

                   new EmployeeDescription()
                   {
                       DescriptionId = 1,
                       EmployeeId = 1

                   },
                   new EmployeeDescription()
                   {
                       DescriptionId = 1,
                       EmployeeId = 2

                   },
                      new EmployeeDescription()
                      {
                          DescriptionId = 2,
                          EmployeeId = 3

                      },
                      new EmployeeDescription()
                      {
                          DescriptionId = 2,
                          EmployeeId = 4


                      });

            //modelBuilder.Entity<Order>().HasData(
            //       new Order()
            //       {
            //           OrderId = 1,
            //           OrderName  = "Trắng"

            //       });
        }
    }
  }

