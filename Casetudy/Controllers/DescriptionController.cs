using Casetudy.Models;
using Casetudy.Views.ViewsModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Controllers
{
    public class DescriptionController:Controller
    {
        private readonly IDescriptionRespository descriptionRespository;
     

        public DescriptionController(IDescriptionRespository descriptionRespository )
        {
            this.descriptionRespository = descriptionRespository;
  
        }

        public IActionResult Index()
        {
            var role = descriptionRespository.Get();
          
            var result = role.Select(a => new Description()
            {
                DescriptionId = a.DescriptionId,
                OriginName = a.OriginName
            }).ToList();
            return View(result); 
         }
         

        
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DescriptionCreateViewsModel model)
        {
            var emp = new Description()
            {
                OriginName = model.Name
            };
            var result = descriptionRespository.Create(emp);
            if(result != null)
            {
                return RedirectToAction("Index");
            }
            return View(model);


        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = descriptionRespository.Gets(id);
            var result = new DescriptionEditViewsModel
            {
               Id = emp.DescriptionId,
                Name = emp.OriginName
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(DescriptionEditViewsModel model)
        {
            if (ModelState.IsValid)
            {
                //var empl = descriptionRespository.Gets(model.Id);
                var em = new Description()
                {
                    DescriptionId = model.Id,
                    OriginName = model.Name
                };
                var result = descriptionRespository.Edit(em);
                if(result != null)
                {
                    return RedirectToAction("Index", new { id = result.DescriptionId });
                }
            }
            return View(model);
           
            
        }
         public IActionResult Delete(int id)
        {
            var emp = descriptionRespository.Gets(id);
            
            if (emp != null)
            {
                descriptionRespository.Delete(id);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
