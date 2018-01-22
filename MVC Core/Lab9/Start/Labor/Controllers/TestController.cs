
using Microsoft.AspNetCore.Mvc;
using Labor.DataAccessLayer;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Labor.ViewModels;
using Labor.Models;
using System.Collections.Generic;

namespace Labor.Controllers
{
    public class TestController : Controller
    {
        private readonly Sales db;
        public TestController(Sales database) { db = database; }

        public ActionResult GetView()
        {

            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees(db);

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if (emp.Salary > 15000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels;
            employeeListViewModel.UserName = "Admin";
            return View("MyView", employeeListViewModel);
        }
    }
}