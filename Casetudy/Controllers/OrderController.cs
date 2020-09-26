using Casetudy.Models;
using Casetudy.Views.ViewsModel.Order;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly IEmployeesRepository employeesRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public OrderController(IOrderRepository orderRepository,IEmployeesRepository employeesRepository, UserManager<ApplicationUser> userManager)
        {
            this.orderRepository = orderRepository;
            this.employeesRepository = employeesRepository;
            this.userManager = userManager;
        }
        
        public IActionResult Index()
        {
            object result = null;
            if (User.IsInRole("Admin")){
                var emp = orderRepository.Get();
               result = emp.Select(a => new Order()
                {
                    Date = a.Date,
                    Carname = a.Carname,
                    City = a.City,
                    Phone = a.Phone,
                    OrderName = a.OrderName,
                    CarColor = a.CarColor,
                    OrderId = a.OrderId
                }).ToList();
            }else
            {
                var user = userManager.GetUserId(User);
                 result = orderRepository.Get().Where(a => a.OrderId == user).Select(b => new Order()
                {
                    Date = b.Date,
                    Carname = b.Carname,
                    City = b.City,
                    Phone = b.Phone,
                    OrderName = b.OrderName,
                    CarColor = b.CarColor,
                    OrderId = b.OrderId
                }).ToList();
            }
            return View(result);
          //ViewBag.Order = GetEmployees();
                 
        }
       
        public IActionResult Create()
        {
            ViewBag.User = userManager.GetUserId(User);
            return View();  
        }
        [HttpPost]
        public IActionResult Create(OrderCreateViewsModel model)
        {
            //var use = userManager.Users.Select(a => a.Id.Contains(model.OrderId));
            //ViewBag.User = orderRepository.Gets(userManager.Users.Select(a => a.Id));
            ViewBag.User = userManager.GetUserId(User);
            ViewBag.Order = GetEmployees();
          var  emp = new Order()
            {
                CarColor = model.Color,
                Date = model.Date,
                OrderName = model.Name,
                City = model.City,
                Phone = model.Phone,
                Carname = model.CarName,
                OrderId = model.OrderId
        };
            ViewBag.User = emp.OrderId;
            var result = orderRepository.Create(emp);
            if(result != null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(string id)
        {
            ViewBag.User = userManager.GetUserId(User);
            var emp = orderRepository.Gets(id);
            var result = new OrderEditViewsModel()
            {
                Phone = emp.Phone,
                Color = emp.CarColor,
                CarName = emp.Carname,
                City = emp.City,
                Name = emp.OrderName,
                Date = emp.Date,
                OrderId = emp.OrderId
            };
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(OrderEditViewsModel model)
        {
            if (ModelState.IsValid)
            {
                var emp = new Order()
                {
                    Date = model.Date,
                    CarColor = model.Color,
                    Carname = model.CarName,
                    City = model.City,
                    OrderName = model.Name,
                    OrderId = model.OrderId,
                    Phone = model.Phone
                };
                var result = orderRepository.Edit(emp);
                if (result != null)
                {
                    return RedirectToAction("Index", new { OrderId = result.OrderId });
                }
            }
            return View(model);
       
        }
        public IActionResult Delete(string id)
        {
            var emp = orderRepository.Gets(id);
            if(emp != null)
            {
                orderRepository.Delete(id);
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        public List<Employees> GetEmployees()
        {
            return employeesRepository.Get().ToList();
        }
    }
}
