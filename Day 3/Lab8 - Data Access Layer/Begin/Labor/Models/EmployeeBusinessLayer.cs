using System.Collections.Generic;

namespace Labor.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            var emp = new Employee();
            emp.FirstName = "John";
            emp.LastName = "Doe";
            emp.Salary = 14000;
            employees.Add(emp);

            emp = new Employee();
            emp.FirstName = "Michael";
            emp.LastName = "Jackson";
            emp.Salary = 16000;
            employees.Add(emp);

            emp = new Employee();
            emp.FirstName = "Robert";
            emp.LastName = "Pattinson";
            emp.Salary = 20000;
            employees.Add(emp);

            return employees;
        }
    }
}