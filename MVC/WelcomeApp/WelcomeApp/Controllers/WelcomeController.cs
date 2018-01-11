using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WelcomeApp.Controllers
{
    public class WelcomeController : Controller
    {
        public string Index()
        {
            return "<h1>MVC</h1>";
        }
    }
}