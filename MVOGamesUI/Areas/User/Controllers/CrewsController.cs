using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceGateway;

namespace MVOGamesUI.Areas.User.Controllers
{
    public class CrewsController : Controller
    {
        Facade facade = new Facade();
        // GET: User/Crews
        public ActionResult Index()
        {
            var crews = facade.GetCrewGateway().GetAll();
            return View(crews);
        }
    }
}