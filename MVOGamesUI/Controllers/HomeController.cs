using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVOGamesUI.Infrastructure;

namespace MVOGamesUI.Controllers
{
    public class HomeController : Controller
    {
        [SelectedTab("home")]
        public ActionResult Index()
        {
            return View();
        }
       
        [SelectedTab("about")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [SelectedTab("contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}