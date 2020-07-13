using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Casetudy.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Casetudy
{
    public class Startup
    {
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = config;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {         
            services.AddMvc(option =>
            {
                option.EnableEndpointRouting = false;
                 var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .Build();
                option.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddScoped<IOrderRepository,SqlOrderRepository>();
            services.AddScoped<ICarbrandRepository,CarbandRepository>();
            services.AddScoped<IEmployeesRepository,SqlEmployeesRespository>();
            services.AddScoped<IDescriptionRespository,SqlDescriptionRespository>();
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(config.GetConnectionString("EmployeesConnection")));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
                app.UseExceptionHandler("/Home/Error");            
                app.UseHsts();
            }
        
            app.UseStaticFiles();
        

            app.UseAuthentication();
            app.UseMvc(routers =>
            {
                routers.MapRoute("default", "{Controller=Home}/{Action=Index}/{id?}");

            });
        }
    }
}
