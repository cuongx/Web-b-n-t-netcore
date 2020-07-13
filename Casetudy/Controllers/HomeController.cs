using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Casetudy.Models;
using Casetudy.Views.ViewsModel;
using System.IO;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System.Collections;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Casetudy.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly IEmployeesRepository employeesRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ICarbrandRepository carbrandRepository;
        private readonly IDescriptionRespository descriptionRespository;
        private readonly IOrderRepository orderRepository;

        public HomeController(IEmployeesRepository employeesRepository,IWebHostEnvironment webHostEnvironment,ICarbrandRepository carbrandRepository,IDescriptionRespository descriptionRespository,IOrderRepository orderRepository)
        {
            this.employeesRepository = employeesRepository;
            this.webHostEnvironment = webHostEnvironment;
            this.carbrandRepository = carbrandRepository;
            this.descriptionRespository = descriptionRespository;
            this.orderRepository = orderRepository;
        }
       

      
        public IActionResult BookCar()
        {
            return View();
        }
      

        [AllowAnonymous]
        public IActionResult Index()
        {

            //ViewBag.Employees = GetDescriptions();
            var employee = employeesRepository.Get().ToList();
            var model = new SearchViewsModels()
            {
                Employees = employee
            };
            var empl = employeesRepository.Get();
            
            var result = new List<ViewModel>();
            result = empl.Select(a => new ViewModel()

            {
                AvatarPath = a.AvatarPath,
                CarbrandId = a.CarbrandId,
                CarName = a.Name,
                Id = a.Id,
                Price = a.Price               
            }).ToList();
           
            foreach (var item in result)
            {
                item.Carbrand = carbrandRepository.Gets(item.CarbrandId);
                            
            }
            //ViewBag.Catogery = GetDescriptions();

            ViewBag.Category = carbrandRepository.Get().ToList();
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult table()
        {
            var empl = employeesRepository.Get();
            var result = empl.Select(a => new Employees()
            {
                AvatarPath = a.AvatarPath,
                Name = a.Name,
                Id = a.Id,
                Price = a.Price  ,               
            });
           
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Carbrands = GetCarbrands();
            ViewBag.Descriptions = GetDescriptions();
            return View();
        }

        [HttpPost]
        public IActionResult Create(HomeCreateViewsModel model)
        {

            var emp = new CreateEmployeeViewsModel()
            {
                Name = model.Name,
                Price = model.Price,
                CarbrandId = model.CarbrandId,
                Descriptions = model.Descriptions
              
            };
            if(model.Avatar != null)
            {
                string routes = Path.Combine(webHostEnvironment.WebRootPath,"images");
                var filename = $"{Guid.NewGuid()}_{model.Avatar.FileName}";
                filename = model.Avatar.FileName;
                var load = Path.Combine(routes,filename);
                using (var stream = new FileStream(load, FileMode.Create))
                {
                    model.Avatar.CopyTo(stream);
                }
           
            };
               emp.AvatarPath = model.Avatar.FileName;
               var hala = employeesRepository.Create(emp);
                if (hala != null)
                {
                return RedirectToAction("table", new { id = hala.EmployId});
               
            }
        
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Products(int id)
        {
            List<Employees> carbands = (from c in employeesRepository.Get() where c.CarbrandId == id select c).ToList();          
            ViewBag.Category = carbrandRepository.Get().ToList();
            return View(carbands);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employees = employeesRepository.Gets(id);
            if(employees == null)
            {
                return View("~/Views/Error/Error.cshtml", id);
            }
            var emp = new HomeEditViewsModel()
            {
                AvatarPath = employees.AvartarPath,
                CarbrandId = employees.CarbrandId,
                Name = employees.Name,
                Price = employees.Price,
                EmployeeId = employees.Id,
                SelectDescriptions = employees.Descriptions,
                Id =employees.Id
            };
            ViewBag.Descriptions = GetDescriptions();
            ViewBag.Carbrands = GetCarbrands();
        
            return View(emp);

        }

        [HttpPost]
        public IActionResult Edit(HomeEditViewsModel model)
        {
            if (ModelState.IsValid)
            {
                var emp = new EditEmployeeViewsModel()
                {
                    AvatarPath = model.AvatarPath,
                    CarbrandId = model.CarbrandId,
                    Descriptions = model.Descriptions,
                    Name = model.Name,
                    Price = model.Price,
                    EmployeeId = model.Id

                };
                var filename = string.Empty;
                if (model.Avatar != null)
                {
                    string file = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    filename = $"{Guid.NewGuid()}_{model.Avatar.FileName}";
                    var load = Path.Combine(file, filename);
                    using (var stream = new FileStream(load, FileMode.Create))
                    {
                        model.Avatar.CopyTo(stream);
                    }
                    emp.AvatarPath = filename;
                    if (!string.IsNullOrEmpty(model.AvatarPath))
                    {
                        string fil = Path.Combine(webHostEnvironment.WebRootPath, "images", model.Avatar.FileName);
                        System.IO.File.Delete(fil);
                    }
                    emp.AvatarPath = filename;
                }
                var empl = employeesRepository.Edit(emp);
                if (empl != null)
                {
                    return RedirectToAction("table", "Home", new {id = empl.EmployeeId});
                }
            }          
            return View();
        }
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            try
            {
                ViewBag.Descriptions = GetDescriptions();

                int.Parse(id.Value.ToString());
                var emp = employeesRepository.Gets(id.Value);
                if (emp == null)
                {
                    return View("~/Views/Error/Error.cshtml", id.Value);
                }               
                var detail = new HomeDetailViewsModel()
                {                   
                    Employee = employeesRepository.Gets(id ?? 1),
                    TitleName = "Employee Details"
                };
                 ViewBag.Category = carbrandRepository.Get().ToList();
              
                return View(emp);
             }
            catch ( Exception e)
            {
                throw e;
            }

        }
                 
        public IActionResult Delete(int id)
        {
            var emp = employeesRepository.Gets(id);
            if (employeesRepository.Delete(id))
            {
                var file = Path.Combine(webHostEnvironment.WebRootPath, "images", emp.AvartarPath);
                System.IO.File.Delete(file);
                return RedirectToAction("table", "Home");
                
            }
            return View();
        }
        public List<Carbrand> GetCarbrands()
        {
            return carbrandRepository.Get().ToList();
        }
        public List<Order> GetOrders()
        {
            return orderRepository.Get().ToList();
        }
        public List<Description> GetDescriptions()
        {
            return descriptionRespository.Get().ToList();
        }
        public IActionResult Search(SearchViewsModels models)
        {
            var key = models.SearchKey.ToLower();
            if (!string.IsNullOrEmpty(key))
            {
                var employee = (from p in employeesRepository.Get() where p.Name.ToLower().Contains(key) select p).ToList();
                var emp = new SearchViewsModels()
                {
                    Employees = employee
                };
                return View(emp);
            }
            else
            {
                return View("~/Views/Error/Error.cshtml");
            }
       
          
            //ViewBag.Descriptions = GetDescriptions();
      
           
        }
       
    }
}
