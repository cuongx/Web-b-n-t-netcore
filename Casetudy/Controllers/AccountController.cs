using Casetudy.Models;
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
    [Authorize]
    public class AccountController:Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
           
        }
        [AllowAnonymous]
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpGet]

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewsModel model)
        {
            if (ModelState.IsValid)
            {
                var emp = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.Email
                };
                var result = await userManager.CreateAsync(user: emp, password: model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user:emp, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var pb in result.Errors)
                    {
                        ModelState.AddModelError("", pb.Description);
                    }

                }
            }
            return View(model);

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewsModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    userName: model.Email,
                    password: model.Password,
                    isPersistent: model.Remember,
                    lockoutOnFailure:false
                    );
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Error");

                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                  
                }
            }
            return View(model);
        }
        public IActionResult Edit()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            if (ModelState.IsValid)
            {
               await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
    
            return View();
        }
        public IActionResult AcceesssDenied()
        {
            return View();
        }

    }
}
