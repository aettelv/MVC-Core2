using System.Collections.Generic;
using Labor.DataAccessLayer;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Labor.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees(Sales db)
        {
            return db.Employees.ToList();
        }
    }
}
