using EmployeeApp.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService empService = new EmployeeService();
        public ActionResult Index()
        {
            IndexViewMoal ivm = new IndexViewMoal();
            ivm.IEmpList = empService.GetList();
            return View(ivm);
        }
        [HttpPost]
        public ActionResult Search(IndexViewMoal ivm)
        {
            if(ivm.IName != null)
            {
                ivm.IEmpList= empService.SearchEmployee(e => e.EmpName == ivm.IName || e.Salary > ivm.ISalary);
                return View("Index",ivm);
            }
            else
            {
                ivm.IEmpList= empService.GetList();
                return View("Index", ivm);
            }
        }

        [HttpGet]
        public ActionResult EditEmployee(string id)
        {
            var employee = empService.GetEmployeeByID(id);
            return View(employee);
        }

        [HttpPost]
        public ActionResult EditEmployee(Employee employee)
        {
            empService.EditEmployee(employee);
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public ActionResult DeleteEmployee(string id)
        {
            empService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            Employee emp = new Employee() { EmpName = "XYZ", HireDate = "Day Month Year", Salary = 0000 };
            return View(emp);
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
            else
            {
                if(employee.EmpName.Equals("XYZ") || employee.HireDate.Equals("Day Month Year") || employee.Salary.Equals(0000))
                {
                    return View(employee);
                }
                else
                {
                    empService.AddEmployee(employee);
                    return RedirectToAction("Index");
                }
            }

        }
    }
}