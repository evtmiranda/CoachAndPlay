using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace WebCoachAndPlay.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}