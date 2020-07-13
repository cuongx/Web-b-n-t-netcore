using Casetudy.Views.ViewsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController:Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        
        public IActionResult Index()
        {            
            var role = roleManager.Roles;
            var result = new List<RoleViewsModel>();
            result = role.Select(a => new RoleViewsModel()
            {
                RoleId = a.Id,
                Name = a.Name
            }).ToList();
           
                    
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            //var emp = await roleManager.FindByIdAsync(id);
            //var result = new RoleEditViewsModel()
            //{
            //    Name = emp.Name,
            //    RoleId = emp.Id
            //};

            //return View(result);
             var result = await roleManager.FindByIdAsync(id);
                if (result != null)
                {
                    var emp = new RoleEditViewsModel()
                    {
                       Id = result.Id,
                        Name = result.Name
                    };
                    return View(emp);
                }
                return View();
            }
        
        [HttpPost]
        public async Task<IActionResult> Edit(RoleEditViewsModel model)
        {
            if (ModelState.IsValid)
            {
                var empl = await roleManager.FindByIdAsync(model.Id);
                if(empl != null)
                {
                    empl.Name = model.Name;

                    var emp = await roleManager.UpdateAsync(empl);
                    if (emp.Succeeded)
                    {
                        return RedirectToAction("Index", "Role");
                    }
                    foreach (var role in emp.Errors)
                    {
                        ModelState.AddModelError("", role.Description);
                    }
                }
                    
            }
            return View(model);
        }
          
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleCreateViewsModel model)
        {
            var result = new IdentityRole()
            {             
                Name = model.RoleName
           };
           var emp = await roleManager.CreateAsync(result);
            if (emp.Succeeded)
            {
                return RedirectToAction("Index", "Role");
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var result = await roleManager.FindByIdAsync(id);
            if(result != null)
            {
              var emp=  await roleManager.DeleteAsync(result);
                if (emp.Succeeded)
                {
                    return RedirectToAction("Index", "Role");
                }
                foreach(var role in emp.Errors)
                {
                    ModelState.AddModelError("", role.Description);
                }
            }
            return View();
        }
      
    }
   
}
