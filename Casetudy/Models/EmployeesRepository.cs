//using Casetudy.Views.ViewsModel;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace Casetudy.Models
//{
//    public class EmployeesRepository : IEmployeesRepository
//    {

//        private List<Employees> Employees;
//        public EmployeesRepository()
//        {
//            Employees = new List<Employees>()
//          {
//              new Employees()
//              {
//                  Id = 1,
//                  Name = "FordEverest",
//                 CarbrandId = 1,
//                  AvatarPath ="images/cd-4.jpg",
//                  Price = 8000000

//              },

//              new Employees()
//              {
//                  Id = 2,
//                  Name = "Lexus2019",
//                   CarbrandId =2,
//                  AvatarPath ="images/cd-5.jpg",
//                  Price = 9000000
//              }

//           };
//        }

//        public Employees Create(Employees employees)
//        {
//            throw new NotImplementedException();
//        }

       

//        public bool Delete(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Employees Edit(Employees employees)
//        {
//            throw new NotImplementedException();
//        }

//        public EditEmployeeViewsModel Edit(EditEmployeeViewsModel employees)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Employees> Get()
//        {
//            throw new NotImplementedException();
//        }

//        public EmployeeDetailsViewsModel Gets(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Employees> Search(string key)
//        {
//            if (string.IsNullOrEmpty(key))
//            {
                
//                    return Employees;
                
               
//            }
//            return Employees.Where(e => e.Name.Contains(key));
//            //public Employees Create(Employees employees)
//            //{
//            //    employees.Id = Employees.Count + 1;
//            //    employees.AvatarPath ="images\\FORRD.jpg";
//            //    Employees.Add(employees);
//            //    return employees;
//            //}



//            //public bool Delete(int id)
//            //{
//            //    var emp = Gets(id);
//            //    if(emp != null)
//            //    {
//            //      Employees.Remove(emp);
//            //        return true;
//            //    }
//            //    return false;

//            //}

//            //public Employees Edit(Employees employees)
//            //{
//            //    var emp = Gets(employees.Id);                       
//            //        emp.Name = employees.Name;
//            //        emp.Price = employees.Price;
//            //        emp.CarbrandId = employees.CarbrandId;         
//            //        return emp;




//            //}

//            //public IEnumerable<Employees> Get()
//            //{
//            //    return Employees;
//            //}

//            //public EmployeeDetailsViewsModel Gets(int id)
//            //{
//            //    return Employees.FirstOrDefault(a => a.Id == id);
//            //}

//        }

//        CreateEmployeeViewsModel IEmployeesRepository.Create(CreateEmployeeViewsModel employees)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
