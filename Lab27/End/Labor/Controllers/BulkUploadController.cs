using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Labor.Filter;
using Labor.ViewModels;
using Labor.Models;
using System.IO;
using Labor.DataAccessLayer;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;
using System.Net.Http.Headers;

namespace Labor.Controllers
{
    public class BulkUploadController : Controller
    {
        private readonly Sales db;
        public BulkUploadController(Sales database) { db = database; }

        [HeaderFooterFilter]
        [AdminFilter]
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }


        [AdminFilter]
        public ActionResult Upload(FileUploadViewModel model, string upload)
        {
            List<Employee> employees = GetEmployees(model);
            EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
            bal.UploadEmployees(employees, db);

            return RedirectToAction("Index", "Employee");
        }

        private static List<Employee> GetEmployees(FileUploadViewModel model)
        {
            List<Employee> employees = new List<Employee>();

            var result = new List<string>();
            using (var reader = new StreamReader(model.FileToUpload.OpenReadStream()))
            {
                //result = reader.ReadToEnd();
                //reader.ReadLine();


                //while (!reader.EndOfStream)
                //{
                //    var line = reader.ReadLine();
                //    var values = line.Split(',');
                //    Employee e = new Employee();
                //    e.FirstName = values[0];
                //    e.LastName = values[1];
                //    e.Salary = int.Parse(values[2]);
                //    employees.Add(e);



                    while (reader.Peek() >= 0)
                        result.Add(reader.ReadLine());
                    //var values = result.Split(',').ToList();
                    Employee e = new Employee();
                    e.FirstName = result[0];
                    e.LastName = result[1];
                    e.Salary = int.Parse(result[2]);
                    employees.Add(e);
                }
                return employees;
            }
        }
    }