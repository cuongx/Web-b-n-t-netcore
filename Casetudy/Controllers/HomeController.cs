using Case.Models;
using Casetudy.Models;
using Casetudy.Models.Gallerys;
using Casetudy.Models.ListAvatar;
using Casetudy.Views.ViewsModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Casetudy.Controllers
{

    public class HomeController : Controller
    {
        private readonly IEmployeesRepository employeesRepository;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ICarbrandRepository carbrandRepository;
        private readonly IDescriptionRespository descriptionRespository;
        private readonly IOrderRepository orderRepository;
        private readonly IGallerysRepository gallerysRepository;
        private readonly AppDbContext context;

        public HomeController(IEmployeesRepository employeesRepository
                            , IWebHostEnvironment webHostEnvironment,
                                     ICarbrandRepository carbrandRepository,
                                     IDescriptionRespository descriptionRespository,
                                     IOrderRepository orderRepository,
                                     IGallerysRepository gallerysRepository,
                                     AppDbContext context)
        {
            this.employeesRepository = employeesRepository;
            this.webHostEnvironment = webHostEnvironment;
            this.carbrandRepository = carbrandRepository;
            this.descriptionRespository = descriptionRespository;
            this.orderRepository = orderRepository;
            this.gallerysRepository = gallerysRepository;
            this.context = context;
        }


      
        public IActionResult BookCar()
        {
            return View();
        }
        public IActionResult Layout()
        {
            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(int pageNumber = 1)
        {

            //ViewBag.Employees = GetDescriptions();
            var employee = employeesRepository.Get().ToList();
            //var model = new SearchViewsModels()
            //{
            //    Employees = employee
            //};
            var empl = employeesRepository.Get();       

            var result = new List<Employees>();
            result = empl.Select(a => new Employees()

            {
                AvatarPath = a.AvatarPath,
                CarbrandId = a.CarbrandId,
                Name = a.Name,
                Id = a.Id,
                Price = a.Price,
            }).ToList();

            //foreach (var item in result)
            //{
            //    item.Carbrand = carbrandRepository.Gets(item.CarbrandId);

            //}
            //ViewBag.Catogery = GetDescriptions();
         //ViewBag.Carbrand =  (from e in context.Employees join c in context.Carbrands on e.CarbrandId equals c.CarbrandId select c).ToList();

            ViewBag.Category = carbrandRepository.Get().ToList();
            return View(await PaginaTedList<Employees>.CreateAsync(context.Employees, pageNumber, 8));
        }
        [AllowAnonymous]
        public IActionResult table()
        {

            //var data = (from e in context.Employees.ToList()
            //            join g in context.Gallerys on e.Id equals g.EmployeeId
            //            join c in context.Carbrands on e.CarbrandId equals c.CarbrandId
            //            select new ViewModel()
            //            {
            //                AvatarPath = e.AvatarPath,
            //                Name = e.Name,
            //                Id = e.Id,
            //                Price = e.Price,
            //                CarbrandId = c.CarbrandId,
            //                Yeard = e.Yeard,
            //                Color = e.Color,
            //                Register = e.Register,                        
            //            })
            var empl = employeesRepository.Get();
            var result = empl.Select(a => new ViewModel()
            {
                AvatarPath = a.AvatarPath,
                Name = a.Name,
                Id = a.Id,
                Price = a.Price,
                CarbrandId = a.CarbrandId,
                Yeard = a.Yeard,
                Color = a.Color,
                Register = a.Register,
       
            }).ToList();
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
        public async Task<IActionResult> Create(HomeCreateViewsModel model)
        {
            if (ModelState.IsValid)
            {

                var emp = new CreateEmployeeViewsModel()
                {
                    Name = model.Name,
                    Price = model.Price,
                    CarbrandId = model.CarbrandId,
                    Descriptions = model.Descriptions,
                    Color = model.Color,
                    Register = model.Register,
                    Yeard = model.Yeard     
                };
                if (model.GalleryFiles != null)
                {
                    string folder = "gallery/";

                    model.Gallery = new List<GalleryModel>();

                    foreach (var file in model.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            Url = await UploadImage(folder, file)
                        };
                       model.Gallery.Add(gallery);
                    }
                    emp.Gallery = model.Gallery;
                    /////emp.Gallery = model.Gallery;
                    if (model.Avatar != null)
                    {
                        string routes = Path.Combine(webHostEnvironment.WebRootPath, "images");
                        var filename = $"{Guid.NewGuid()}_{model.Avatar.FileName}";
                        filename = model.Avatar.FileName;
                        var load = Path.Combine(routes, filename);
                        using (var stream = new FileStream(load, FileMode.Create))
                        {
                            model.Avatar.CopyTo(stream);
                        }

                    };
                
                    emp.AvatarPath = model.Avatar.FileName;
                    var hala = employeesRepository.Create(emp);
                    if (hala != null)
                    {
                        return RedirectToAction("table", new { id = hala.EmployId });

                    }

                }      
            }
            return View();
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
            if (employees == null)
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
                Color = employees.Color,
                Register =employees.Register,
                Yeard = employees.Yeard,
                Gallery = employees.Gallery
                 
                
            };
            ViewBag.Gallerys = (from g in context.Gallerys where g.EmployeeId == emp.EmployeeId select g).ToList();
            ViewBag.Avatar = employees.AvartarPath;
            ViewBag.Descriptions = GetDescriptions();
            ViewBag.Carbrands = GetCarbrands();

            return View(emp);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(HomeEditViewsModel model)
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
                    EmployeeId = model.EmployeeId,
                    Color = model.Color,
                    Register= model.Register,
                    Yeard =model.Yeard

                };
                 
                if(model.GalleryFiles != null)
                {
                    string folder = "gallery/";
                    model.Gallery = new List<GalleryModel>();
                    foreach (var gall in model.GalleryFiles)
                    {
                        var images = new GalleryModel()
                        {                          
                            Name = gall.FileName,
                            Url = await UploadImage(folder, gall)
                        };
                        model.Gallery.Add(images);
                    }
                    emp.Gallery = model.Gallery;
                }
                if (!string.IsNullOrEmpty(model.Gallery.FirstOrDefault().Name))
                {
                    List<Gallery> galleries = (from e in context.Gallerys where e.EmployeeId == model.EmployeeId select e).ToList();
                    foreach (var tim in galleries)
                    {
                        var fi = Path.Combine(webHostEnvironment.WebRootPath, "gallery", tim.Name);
                        System.IO.File.Delete(fi);
                    }

                    context.Gallerys.RemoveRange(galleries);
                    context.SaveChanges();
                }

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
                    //emp.AvatarPath = filename;
                }
                var empl = employeesRepository.Edit(emp);
                if (empl != null)
                {
                    return RedirectToAction("table", "Home", new { id = empl.EmployeeId });
                }
            }
            return View();
        }
        [AllowAnonymous]
        public  IActionResult Details(int? id)
        {
            try
            {
                ViewBag.Descriptions = GetDescriptions();

                int.Parse(id.Value.ToString());
                var emp =  employeesRepository.Gets(id.Value);
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
                var product = (from e in context.Employees where e.Id == emp.Id ||  e.CarbrandId == emp.CarbrandId  select e).ToList();
                product.Remove(context.Employees.Find(id));
                ViewBag.Products = product.Take(4);
                return View(emp);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public IActionResult Delete(List<ViewModel> model)
        {
            List<Employees> employees = new List<Employees>();
            foreach (var iteam in model)
            {
                if (iteam.Emps.Selected)
                {
                    var emp = context.Employees.Find(iteam.Id);
                    employees.Add(emp);
                    var file = Path.Combine(webHostEnvironment.WebRootPath, "images", emp.AvatarPath);
                    System.IO.File.Delete(file);

           
                    if (employees != null)
                    {                      
                        List<Gallery> galleries = (from e in context.Gallerys where e.EmployeeId == iteam.Id select e).ToList();
                        foreach(var tim in galleries)
                        {
                            var fi = Path.Combine(webHostEnvironment.WebRootPath, "gallery", tim.Name);
                            System.IO.File.Delete(fi);
                        }
                  
                        context.Gallerys.RemoveRange(galleries);
                        context.SaveChanges();
                    }

                    if (employees != null)
                    {
                        List<EmployeeDescription> elist = (from e in context.EmployeeDescriptions where e.DescriptionId == iteam.Id select e).ToList();
                        context.EmployeeDescriptions.RemoveRange(elist);
                        context.SaveChanges();

                    }
                    context.Employees.RemoveRange(employees);
                    context.SaveChanges();
                }
               
              }
            return RedirectToAction("table", "Home");              
           
        }
        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
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
        public List<Gallery> GetGallerys()
        {
            return gallerysRepository.Gets().ToList();
        }
        [AllowAnonymous]
        [Route("Home/Search")]
        public IActionResult Search(string keyword)
        {
            //var key = models.SearchKey.ToLower();
        
            if (!string.IsNullOrEmpty(keyword))
            {
                var emp = (from e in employeesRepository.Get().Where(a => a.Name.ToLower().Contains(keyword)) select e).ToList();
                if(emp.Count == 0)
                {
                    ViewBag.Products = "Search Products Not Found";
                }
              
                var result = emp.Select(a => new SearchEmployeeViewsModel()
                {
                    AvatarPath = a.AvatarPath,
                    CarbrandId = a.CarbrandId,
                    Color = a.Color,
                    Id = a.Id,
                    Name = a.Name,
                    Price = a.Price,
                    Register = a.Register,
                    Yeard = a.Yeard
                }).ToList();
                    /*(from e in employeesRepository.Get().Where(a => a.Name == keyword) select e).ToList();*/
                var post = new List<SearchEmployeeViewsModel>();             
               foreach (var iteam in result)
                {
                    if (iteam.Name.ToLower().Contains(keyword))
                    {
                        post.Add(iteam);
                    }
                  

                }
                return View(post);
            }
            else
            {
                return View("~/Views/Error/Error.cshtml");
            }

            //public IActionResult Search(SearchViewsModels models)
            //{
            //    var key = models.SearchKey.ToLower();
            //    if (!string.IsNullOrEmpty(key))
            //    {
            //        var employee = (from p in employeesRepository.Get() where p.Name.ToLower().Contains(key) select p).ToList();
            //        if(employee.Count == 0)
            //        {
            //            ViewBag.Products = "Search Products Not Found";
            //        }
            //        var emp = new SearchViewsModels()
            //        {
            //            Employees = employee
            //        };
            //        return View(emp);
            //    }
            //    else
            //    {
            //        return View("~/Views/Error/Error.cshtml");
            //    }

        }

}
}
