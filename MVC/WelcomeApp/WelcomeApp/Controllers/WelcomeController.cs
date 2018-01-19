using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WelcomeApp.Models.ViewModel;

namespace WelcomeApp.Controllers
{
    public class WelcomeController : Controller
    {
        public string Index()
        {
            return "<h1>MVC</h1>";
        }
        public string GetEmployee(int? id)
        {
            return "Display employee of Dept " + id;
        }
        public ActionResult SayHello(string name)
        {
            return Content("Hello "+name);
        }
        public ActionResult Browse()
        {
            ViewBag.Message = "Hello Swabhav";
            return View();
        }
        public ActionResult DisplayEmp()
        {
            DisplayEmpVM vm = new DisplayEmpVM() { Name = "Akshay", Salary = 20000, DateOFJoining = "17th July 2017" };
            return View(vm);
        }
        public ActionResult DisplayEmployees()
        {
            DisplayEmpVM vm1 = new DisplayEmpVM() { Name = "Akshay", Salary = 20000, DateOFJoining = "17th July 2017" };
            DisplayEmpVM vm2 = new DisplayEmpVM() { Name = "Ryan", Salary = 15000, DateOFJoining = "4th Jan 2018" };
            DisplayEmpVM vm3 = new DisplayEmpVM() { Name = "Austin", Salary = 25000, DateOFJoining = "17th Feb 2017" };
            var Employees = new List<DisplayEmpVM> { vm1, vm2, vm3 };
            return Json(vm1,JsonRequestBehavior.AllowGet);
        }
    }
}