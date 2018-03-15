using System.Collections.Generic;
using Labor.DataAccessLayer;
using Labor.Models;
using Labor.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Labor.Controllers
{
    public class TestController : Controller
    {
        private readonly Sales db;

        public TestController(Sales database)
        {
            db = database;
        }

        public ActionResult GetView()
        {
            var employeeListViewModel = new EmployeeListViewModel();

            var empBal = new EmployeeBusinessLayer();
            var employees = empBal.GetEmployees(db);

            var empViewModels = new List<EmployeeViewModel>();

            foreach (var emp in employees)
            {
                var empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if (emp.Salary > 15000)
                    empViewModel.SalaryColor = "yellow";
                else
                    empViewModel.SalaryColor = "green";
                empViewModels.Add(empViewModel);
            }

            employeeListViewModel.Employees = empViewModels;
            employeeListViewModel.UserName = "Admin";
            return View("MyView", employeeListViewModel);
        }
    }
}