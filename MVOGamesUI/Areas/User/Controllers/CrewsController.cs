using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceGateway;
using ServiceGateway.Models;
using MVOGamesUI.Areas.User.ViewModels;
using BusinessLogic.CrewLogic;

namespace MVOGamesUI.Areas.User.Controllers
{
    [Authorize(Roles = "user")]
    public class CrewsController : Controller
    {
        CrewPermission cp = new CrewPermission();
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
            var user = Auth.user;
            var crew = facade.GetCrewGateway().Get(id);
            var platformgamesForCrews = facade.GetCrewGameSuggestionGateway().GetAll().ToList().Where(p=> p.CrewId == crew.Id).ToList();
            var applications = facade.GetCrewApplicationGateway().GetAll().ToList().Where(c => c.CrewId == crew.Id);
            MyCrewViewModel ccgs = new MyCrewViewModel(user, crew, platformgamesForCrews, applications.ToList());

            return View(ccgs);
        }
        //[ChildActionOnly]
        //public ActionResult ApplyForCrew(int crewId)
        //{
        //    var crew = facade.GetCrewGateway().Get(crewId);
        //    if (cp.IsFull(crew.Users.Count))
        //    {
        //        return Content("Crew is already full");
        //    }
        //    CrewApplication ca = new CrewApplication() { CrewId = crewId, Crew = crew, UserId = Auth.user.Id, User = Auth.user };
        //    if (ca == null)
        //    {
        //        return Content("crew doesnt exist");
        //    }
        //    facade.GetCrewApplicationGateway().Create(ca);
        //    return Content("lol");
        //}
        public ActionResult ApplyForCrew(int crewId)
        {
            var crew = facade.GetCrewGateway().Get(crewId);
            if (cp.IsFull(crew.Users.Count))
            {
                
                return RedirectToAction("Index");
            }
            CrewApplication ca = new CrewApplication() { CrewId = crewId, Crew = crew, UserId = Auth.user.Id, User = Auth.user };
            if (ca == null)
            {
                return HttpNotFound();
            }
            facade.GetCrewApplicationGateway().Create(ca);
            return RedirectToAction("Index");
        }

        public ActionResult HandleApplications(int userId, int? crewId, int? appId, bool accepted)
        {
            if (appId == null || crewId==null)
            {
                return HttpNotFound();
            }
            if (accepted)
            {
                var crew = facade.GetCrewGateway().Get(crewId);
                var user = facade.GetUserGateway().Get(userId);
                crew.Users.Add(user);
                facade.GetCrewGateway().Update(crew);
            }
            facade.GetCrewApplicationGateway().Delete(appId);
            return RedirectToAction("MyCrew", "Crews", new { id = crewId});
        }
    }

}