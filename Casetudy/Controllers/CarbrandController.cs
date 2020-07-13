using Casetudy.Models;
using Casetudy.Views.ViewsModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Controllers
{
    public class CarbrandController : Controller
    {
        private readonly ICarbrandRepository carbrandRepository;

        public CarbrandController(ICarbrandRepository carbrandRepository)
        {
            this.carbrandRepository = carbrandRepository;

        }

        public IActionResult Index()
        {
            var role = carbrandRepository.Get();
            var data = new List<Carbrand>();
            data = role.Select(r => new Carbrand()
            {
                CarbrandId = r.CarbrandId,
                CarbrandName= r.CarbrandName
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
                Name = emp.CarbrandName
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
                    CarbrandName = model.Name
                };
                var result = carbrandRepository.Edit(car);
                if (result != null)
                {
                    return RedirectToAction("Index","Carbrand");
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
