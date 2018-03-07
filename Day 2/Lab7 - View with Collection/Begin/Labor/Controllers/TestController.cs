using Labor.Models;
using Labor.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Labor.Controllers
{
    public class TestController : Controller
    {
        public ActionResult GetView()
        {
            var emp = new Employee();
            emp.FirstName = "Sukesh";
            emp.LastName = "Marla";
            emp.Salary = 20000;

            var vmEmp = new EmployeeViewModel();
            vmEmp.EmployeeName = emp.FirstName + " " + emp.LastName;
            vmEmp.Salary = emp.Salary.ToString("C");
            if (emp.Salary > 15000)
                vmEmp.SalaryColor = "yellow";
            else
                vmEmp.SalaryColor = "green";
            vmEmp.UserName = "Admin";
            return View("MyView", vmEmp);
        }
    }
}