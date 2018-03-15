using System.Collections.Generic;
using Labor.DataAccessLayer;
using Labor.Models;
using Labor.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Labor.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly Sales db;

        public EmployeeController(Sales database)
        {
            db = database;
        }

        public ActionResult Index()
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
            return View("Index", employeeListViewModel);
        }

        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }

        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    var empBal = new EmployeeBusinessLayer();
                    empBal.SaveEmployee(e, db);
                    return RedirectToAction("Index");
                case "Cancel":
                    return RedirectToAction("Index");
            }

            return new EmptyResult();
        }
    }
}