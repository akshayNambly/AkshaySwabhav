using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApp.Models.ViewModel
{
    public class IndexViewMoal
    {
        public string IName { get; set; }
        public int ISalary { get; set; }
        public List<Employee> IEmpList { get; set; }
    }
}