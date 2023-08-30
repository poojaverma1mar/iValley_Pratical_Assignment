using Employees_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employees_System.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        private readonly EmployeeDbContext _dbContext;

        public EmployeeController()
        {
            this._dbContext = new EmployeeDbContext();
        }
        public ActionResult Index()
        {
            var employeeList = this._dbContext.Employee.ToList();
            return View(employeeList);
        }
        public ActionResult AddEmployee()
        {
            var employeeViewModel = new EmployeeViewModel()
            {               
                Employee = new Employee()
            };
            return View("AddEmployee", employeeViewModel);
        }
        

        [HttpPost]
        public ActionResult Save(Employee employee)
        {           

            if (employee.Id == 0)
            {
                employee.CreatedDate = DateTime.Now;
                this._dbContext.Employee.Add(employee);
            }
            else
            {
                var employeesDb = this._dbContext.Employee.FirstOrDefault(x => x.Id == employee.Id);
                employeesDb.FirstName = employee.FirstName;
                employeesDb.LastName = employee.LastName;
                employeesDb.City = employee.City;
                employeesDb.Zip = employee.Zip;
                
            }

            this._dbContext.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }

        public ActionResult Edit(int id)
        {
            var employees = this._dbContext.Employee.FirstOrDefault(x => x.Id == id);

            var viewModel = new EmployeeViewModel()
            {
                Employee = employees
            };
            return PartialView("EditEmployee", viewModel);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            var employeesDb = this._dbContext.Employee.FirstOrDefault(x => x.Id == employee.Id);
            employeesDb.FirstName = employee.FirstName;
            employeesDb.LastName = employee.LastName;
            employeesDb.City = employee.City;
            employeesDb.Zip = employee.Zip;
            this._dbContext.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }


        public ActionResult AddEmployeeSalary()
        {
            var employeeViewModel = new EmployeeViewModel()
            {
                Employees = this._dbContext.Employee.ToList(),                
            };
            return View("AddEmployeeSalary", employeeViewModel);
        }
        [HttpPost]
        public ActionResult AddEmployeeSalary(EmployeeSalary employeeSalary)
        {


            employeeSalary.CreatedDate = DateTime.Now;
            this._dbContext.EmployeeSalary.Add(employeeSalary);

            this._dbContext.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }

        public ActionResult ShowEmployeeSalary(int id)
        {
            var employeesSalaryList = this._dbContext.EmployeeSalary.Where(b => b.SalaryDate.Year == DateTime.Now.Year)
                      .ToList();

            
            return PartialView("EmployeeSalary", employeesSalaryList);
        }
    }
}