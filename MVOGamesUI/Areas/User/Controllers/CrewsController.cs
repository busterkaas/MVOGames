using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceGateway;
using ServiceGateway.Models;

namespace MVOGamesUI.Areas.User.Controllers
{
    [Authorize(Roles = "user")]
    public class CrewsController : Controller
    {
        Facade facade = new Facade();
        // GET: User/Crews
        public ActionResult Index()
        {
            var crews = facade.GetCrewGateway().GetAll().ToList();
            return View(crews);
        }

        public ActionResult MyCrew(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var crew = facade.GetCrewGateway().Get(id);

            return View(crew);
        }
    }
}