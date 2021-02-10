using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MockAssessment6.DALModels;
using MockAssessment6.Models;
using MockAssessment6.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MockAssessment6.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: /<controller>/
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        //create a model for the Employee IActionResult -- models folders.. create, EmployeeViewModel, EmployeeResultViewModel, RetirementInfoViewModel -- refractored code. EmployeeCurrent
        public IActionResult Employee()
        {
            return View();
        }

        public IActionResult EmployeeResult(EmployeeViewModel model)
        {
            var employee = new EmployeeDAL();
            employee.FirstName = model.Employees.FirstName;
            employee.Age = model.Employees.Age;
            employee.Salary = model.Employees.Salary;
            // adding the employee into the database
            _employeeDbContext.Employees.Add(employee);
            _employeeDbContext.SaveChanges();
            var employeeList = _employeeDbContext.Employees
                .Select(employeeDAL => new EmployeeCurrent() { Id = employeeDAL.Id, FirstName = employeeDAL.FirstName, Age = employeeDAL.Age, Salary = employeeDAL.Salary })
                .ToList();
            var viewModel = new EmployeeResultViewModel();
            viewModel.Employees = employeeList;
            return View(viewModel);
        }
        // displaying the table of the employee results -- returning all the employees added to the database
        public IActionResult ReturnAllEmployeeResult()
        {
            var employeeList = _employeeDbContext.Employees
                .Select(employeeDAL => new EmployeeCurrent() { Id = employeeDAL.Id, FirstName = employeeDAL.FirstName, Age = employeeDAL.Age, Salary = employeeDAL.Salary })
                .ToList();
            var viewModel = new EmployeeResultViewModel();
            viewModel.Employees = employeeList;
            return View("EmployeeResult", viewModel);
        }

        // if they are above the age of 60 they can retire, --- else false -- you to young to retire
        public IActionResult RetirementInfo(int Id)
        {
            var employee = GetEmployeeWhereIdIsFirstOrDefault(Id);
            var model = new RetirementInfoViewModel();
            model.Id = Id;
            model.Benefits = employee.Salary * 60 / 100;
            if (employee.Age > 60)
            {
                model.CanRetire = true;
            }
            else
            {
                model.CanRetire = false;
            }
            return View(model);
        }


        private EmployeeCurrent GetEmployeeWhereIdIsFirstOrDefault(int id)
        {
            EmployeeDAL employeeDAL = _employeeDbContext.Employees
                .Where(employee => employee.Id == id)
                .FirstOrDefault();
            var employee = new EmployeeCurrent();
            employee.FirstName = employeeDAL.FirstName;
            employee.Age = employeeDAL.Age;
            employee.Salary = employeeDAL.Salary;
            return employee;
        }

    }
}
