using Casetudy.Models;
using Casetudy.Views.ViewsModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Controllers
{
    public class CarbrandController : Controller
    {
        private readonly ICarbrandRepository carbrandRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        public CarbrandController(ICarbrandRepository carbrandRepository,IWebHostEnvironment webHostEnvironment)
        {
            this.carbrandRepository = carbrandRepository;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var role = carbrandRepository.Get();
            var data = new List<Carbrand>();
            data = role.Select(r => new Carbrand()
            {
                CarbrandId = r.CarbrandId,
                CarbrandName= r.CarbrandName,
                AvatarPath = r.AvatarPath
            }).ToList();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CarbrandCreateVieswModel model)
        {
            var emp = new Carbrand()
            {
                CarbrandName = model.Name,
            };
            var empl = carbrandRepository.Create(emp);
            if (model.AvatarPath != null)
            {
                string routes = Path.Combine(webHostEnvironment.WebRootPath, "icon");
                var filename = $"{Guid.NewGuid()}_{model.AvatarPath.FileName}";
                filename = model.AvatarPath.FileName;
                var load = Path.Combine(routes, filename);
                using (var stream = new FileStream(load, FileMode.Create))
                {
                    model.AvatarPath.CopyTo(stream);
                }

            };

            emp.AvatarPath = model.AvatarPath.FileName;
            var hala = carbrandRepository.Create(emp);
            if (hala != null)
            {
                return RedirectToAction("table", new { id = hala.CarbrandId });

            }
            if (empl != null)
            {             
                return RedirectToAction("Index", "Carbrand");
            }
            return View(emp);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = carbrandRepository.Gets(id);
            var em = new CarbrandEditViewsModel()
            {
                Id = emp.CarbrandId,
                Name = emp.CarbrandName,
                Avatar = emp.AvatarPath
            };
            return View(em);
        }
        //[HttpPost]
        //public IActionResult Edit(CarbrandEditViewsModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var haha = carbrandRepository.Get(model.Id);
        //        var empl = new Carbrand()
        //        {
        //            CarbrandId = model.Id,
        //            CarbrandName = model.Name
        //        };
        //        var result = carbrandRepository.Edit(empl);
        //        if (result != null)
        //        {
        //            return RedirectToAction("Index", "Carbrand");
        //        };
        //    }

        //    return View(model);
        //}
        [HttpPost]
        public IActionResult Edit(CarbrandEditViewsModel model)
        {
            if (ModelState.IsValid)
            {
                var car = new Carbrand()
                {
                    CarbrandId = model.Id,
                    CarbrandName = model.Name,           
                           
                };
                var filename = string.Empty;
                if (model.AvatarPath != null)
                {
                    string file = Path.Combine(webHostEnvironment.WebRootPath, "icon");
                    filename = $"{Guid.NewGuid()}_{model.AvatarPath.FileName}";
                    var load = Path.Combine(file, filename);
                    using (var stream = new FileStream(load, FileMode.Create))
                    {
                        model.AvatarPath.CopyTo(stream);
                    }                  
                    if (!string.IsNullOrEmpty(model.Avatar))
                    {
                        string fil = Path.Combine(webHostEnvironment.WebRootPath, "icon", model.AvatarPath.FileName);
                        System.IO.File.Delete(fil);
                    }
                    car.AvatarPath = filename;
                }
                var empl = carbrandRepository.Edit(car);
                if (empl != null)
                {
                    return RedirectToAction("Index", new { id = empl.CarbrandId });
                }
             
            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
           var car = carbrandRepository.Gets(id);
           if(car != null)
            {
                carbrandRepository.Delete(car.CarbrandId);
                return RedirectToAction("Index", "Carbrand");
            }
            return View();
        }
      
    }       
}
