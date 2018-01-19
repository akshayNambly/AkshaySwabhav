using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WelcomeApp.Models.ViewModel;

namespace WelcomeApp.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            LoginVM user = new LoginVM() { Name = "xyz", Password = "xyz",Status="Pending" };
            return View(user);
        }
        public ActionResult Swabhav()
        {
            return Redirect("http://swabhavtechlabs.com/");
        }
        [HttpPost]
        public ActionResult Login(LoginVM userDetails)
        {
            if (userDetails.Name == "Admin" && userDetails.Password.Equals("Admin"))
            {
                userDetails.Status = "Succesfull";
                return View(userDetails);
            }
            else
            {
                userDetails.Status = "Access Denied";
                return View(userDetails);
            }
        }
    }
}