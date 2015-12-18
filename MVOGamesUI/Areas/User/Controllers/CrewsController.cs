using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceGateway;
using MVOGamesUI.Areas.User.ViewModels;
using BusinessLogic.CrewLogic;
using DTOModels.Models;

namespace MVOGamesUI.Areas.User.Controllers
{
    [Authorize(Roles = "user")]
    public class CrewsController : Controller
    {
        CrewPermission cp = new CrewPermission();
        Facade facade = new Facade();
        // GET: User/Crews
        public ActionResult Index(String message)
        {
            var crews = facade.GetCrewGateway().GetAll().ToList();
            ViewBag.Message = message;
            return View(crews);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, CrewImgUrl")]CrewDTO crew)
        {
            if (!ModelState.IsValid)
            {
                return View(crew);
            }
            int userId = Auth.user.Id;
            if (!MaxCrewsJoined(userId)) {
            
            crew.CrewLeaderId = userId;
            facade.GetCrewGateway().Create(crew);
            
            var myCrew = facade.GetCrewGateway().GetAll().Where(c => c.CrewLeaderId ==userId).Last();
            myCrew.Users.Add(Auth.user);
            facade.GetCrewGateway().Update(myCrew);

            return RedirectToAction("MyCrew", "Crews", new { id = myCrew.Id});
            }
            ViewBag.ErrorMessage = "You are only allowed to be in 3 crews!";
            return View(crew);
        }

        public ActionResult DeleteCrew(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var crewGameSuggestions = facade.GetCrewGameSuggestionGateway().GetAll().Where(cg => cg.CrewId == id);
            
            foreach(var cgs in crewGameSuggestions)
            {
                var suggestionUsers = facade.GetSuggestionUsersGateway().GetAll().Where(su => su.CrewGameSuggestionId == cgs.Id);
                foreach(var su in suggestionUsers)
                {
                    facade.GetSuggestionUsersGateway().Delete(su.Id);
                }
                facade.GetCrewGameSuggestionGateway().Delete(cgs.Id);
            }
            facade.GetCrewGateway().Delete(id);

            return RedirectToAction("Index", "Profile");
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
            if (cp.CrewIsFull(crew.Users.Count))
            {

                return RedirectToAction("Index", new { message = "The chosen crew is full!" });
            }
            if (MaxCrewsJoined(Auth.user.Id))
            {
                return RedirectToAction("Index", new { message = "You can maximum join 3 crews!" });
            }
            CrewApplicationDTO ca = new CrewApplicationDTO() { CrewId = crewId, Crew = crew, UserId = Auth.user.Id, User = Auth.user };
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
                if (!MaxCrewsJoined(userId)) { 
                var crew = facade.GetCrewGateway().Get(crewId);
                var user = facade.GetUserGateway().Get(userId);
                crew.Users.Add(user);
                facade.GetCrewGateway().Update(crew);
                }
            }
            facade.GetCrewApplicationGateway().Delete(appId);
            return RedirectToAction("MyCrew", "Crews", new { id = crewId});
        }

        public ActionResult LeaveCrew(int? crewId)
        {
            if (crewId == null)
            {
                return HttpNotFound();
            }
            int userId = Auth.user.Id;
            var crew = facade.GetCrewGateway().Get(crewId);
            var suggestionUsers = facade.GetSuggestionUsersGateway().GetAll().Where(su => su.CrewGameSuggestion.CrewId == crewId).ToList();
            foreach(var su in suggestionUsers)
            {
                if(su.UserId == userId) { 
                facade.GetSuggestionUsersGateway().Delete(su.Id);
                }
            }
            crew.Users.RemoveAll(u => u.Id == userId);
            facade.GetCrewGateway().Update(crew);


            return RedirectToAction("Index", "Profile", new { area = "User" });
        }

        public bool MaxCrewsJoined(int userId)
        {
            var crews = facade.GetCrewGateway().GetAll().ToList();

                var myCrews = from c in crews
                               where c.Users.Any(user => user.Id == userId)
                               select c;

            return cp.MaxCrewsJoined(myCrews.Count());
        }
    }
}