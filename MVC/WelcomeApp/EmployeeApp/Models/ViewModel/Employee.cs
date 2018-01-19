using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeApp.Models.ViewModel
{
    public class Employee
    {
        [Key]
        public string EmpID { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        public string EmpName { get; set; }
        [Required(ErrorMessage ="Salary is Required")]
        public int Salary { get; set; }
        public string HireDate { get; set; }
    }
}