﻿using System.ComponentModel.DataAnnotations;

namespace Labor.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Enter First Name")]
        public string FirstName { get; set; }
        [StringLength(5, ErrorMessage = "Last Name leght should br greater than 5")]
        public string LastName { get; set; }
        public int Salary { get; set; }
    }
}