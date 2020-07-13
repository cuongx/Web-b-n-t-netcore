using Casetudy.Models;
using Casetudy.Views.ViewsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Controllers
{  
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        public SignInManager<ApplicationUser> signInManager { get; }

        public UserController(UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        public  IActionResult Index()
        {
            var user = userManager.Users;
            if (user != null && user.Any())
            {
                //var result = new List<UserViewsModel>();
                var result = user.Select(a => new UserViewsModel()
                {
                    UserID = a.Id,
                    Email = a.Email,
                    RoleName = a.Email,
                }).ToList();
                foreach (var use in result)
                {
                    use.RoleName = GetRoleName(use.UserID);
                }
                return View(result);

            }
            return View();

        }
        public string GetRoleName(string Id)
        {
            var user = Task.Run(async () => await userManager.FindByIdAsync(Id)).Result;
            var role = Task.Run(async () => await userManager.GetRolesAsync(user)).Result;
            return role != null ? string.Join("", role) : string.Empty;
        }
        public IActionResult Create()
        {
            ViewBag.Roles = roleManager.Roles;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(UserCreateViewsModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email,                  
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.RoleId))
                    {
                        var role = await roleManager.FindByIdAsync(model.RoleId);
                        var addRoleresult = await userManager.AddToRoleAsync(user, role.Name);

                        if (addRoleresult.Succeeded)
                        {
                            return RedirectToAction("Index", "User");
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        [HttpGet]     
        public async Task<IActionResult> Edit(string id)
        {
            var result = await userManager.FindByIdAsync(id);
            if (result != null)
            {
                var emp = new UserEditViewsModel()
                {
                    Email = result.Email,
                    RoleId = result.Id
                };
                var role = await userManager.GetRolesAsync(result);
                if (role != null && role.Any())
                {
                    var name = await roleManager.FindByNameAsync(role.FirstOrDefault());
                    emp.RoleId = name.Id;
                }
                ViewBag.Role = roleManager.Roles;
                return View(emp);
            }

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewsModel model)
        {
            if (ModelState.IsValid)
            {
                var emp = await userManager.FindByIdAsync(model.Id);
                if (emp != null)
                {                  
                    emp.UserName = model.Email;
                    emp.Email = model.Email;                  
                    emp.Id = model.Id;
                }
                var num = await userManager.UpdateAsync(emp);
                if (num.Succeeded)
                {
                    var rolename = await userManager.GetRolesAsync(emp);
                    var deRole = await userManager.RemoveFromRolesAsync(emp, rolename);
                    if (!string.IsNullOrEmpty(model.RoleId))
                    {
                        var role = await roleManager.FindByIdAsync(model.RoleId);
                        var addRoleresult = await userManager.AddToRoleAsync(emp, role.Name);
                        if (addRoleresult.Succeeded)
                        {
                            return RedirectToAction("Index", "User");
                        }
                        foreach (var error in addRoleresult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                    }
                    return RedirectToAction("Index", "User");
                }
                foreach (var pb in num.Errors)
                {
                    ModelState.AddModelError("", errorMessage: "Can not match");
                }

            };

            return View(model);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var result = await userManager.FindByIdAsync(id);
            if (result != null)
            {
                await userManager.DeleteAsync(result);
                return RedirectToAction("Index", "User");
            }
            return View();
        }
    }
}

