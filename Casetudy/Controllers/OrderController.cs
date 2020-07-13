using Casetudy.Models;
using Casetudy.Views.ViewsModel.Order;
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

        public OrderController(IOrderRepository orderRepository,IEmployeesRepository employeesRepository)
        {
            this.orderRepository = orderRepository;
            this.employeesRepository = employeesRepository;
        }
        public IActionResult Index()
        {
            ViewBag.Order = GetEmployees();
            var emp = orderRepository.Get();
            var result = emp.Select(a => new Order()
            {
                Date = a.Date,
                CarColor = a.CarColor,
                City = a.City,
                Phone = a.Phone,
                OrderName = a.OrderName,
                Carname = a.Carname,
                OrderId =a.OrderId
            }).ToList();
            return View(result);
        }
       
        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        public IActionResult Create(OrderCreateViewsModel model)
        {
            ViewBag.Order = GetEmployees();
            var emp = new Order()
            {
                CarColor = model.Color,
                Date = model.Date,
                OrderName = model.Name,
                City = model.City,
                Phone = model.Phone,      
                Carname = model.CarName
            };
            var result = orderRepository.Create(emp);
            if(result != null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var emp = orderRepository.Gets(id);
            var result = new OrderEditViewsModel()
            {
                Phone = emp.Phone,
                Color = emp.CarColor,
                CarName = emp.Carname,
                City = emp.City,
                Name = emp.OrderName,
                Date = emp.Date,
                Id = emp.OrderId
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
                    OrderId = model.Id,
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
        public IActionResult Delete(int id)
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
