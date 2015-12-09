using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVOGamesUI.Infrastructure;
using ServiceGateway;
using ServiceGateway.Models;

namespace MVOGamesUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [SelectedTab("crews")]
    public class CrewsController : Controller
    {
        private Facade facade = new Facade();
        // GET: Admin/Crews
        public ActionResult Index()
        {
            var crews = facade.GetCrewGateway().GetAll();
            return View(crews);
        }

        // GET: Admin/Crews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crew crew = facade.GetCrewGateway().Get(id);
            if (crew == null)
            {
                return HttpNotFound();
            }
            return View(crew);
        }

        // GET: Admin/Crews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Crews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CrewImgUrl,CrewLeaderId")] Crew crew)
        {
            if (ModelState.IsValid)
            {
                facade.GetCrewGateway().Create(crew);

                return RedirectToAction("Index");
            }
            return View(crew);
        }

        // GET: Admin/Crews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crew crew = facade.GetCrewGateway().Get(id);
            
            if (crew == null)
            {
                return HttpNotFound();
            }
            return View(crew);
        }

        // POST: Admin/Crews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CrewImgUrl,CrewLeaderId, Users")] Crew crew)
        {
            if (ModelState.IsValid)
            {
                facade.GetCrewGateway().Update(crew);

                return RedirectToAction("Index");
            }
            return View(crew);
        }

        // GET: Admin/Crews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crew crew = facade.GetCrewGateway().Get(id);
            if (crew == null)
            {
                return HttpNotFound();
            }
            return View(crew);
        }

        public ActionResult DeleteUserFromCrew(int? id, int? crewId)
        {
            if (id == null || crewId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crew crew = facade.GetCrewGateway().Get(crewId);
            //ServiceGateway.Models.User user = facade.GetUserGateway().Get(id);
            if (crew == null )
            {
                return HttpNotFound();
            }

            crew.Users.RemoveAll(u => u.Id == id);
            facade.GetCrewGateway().Update(crew);

            return RedirectToAction("Edit"+ "/"+crewId);

        }

        // POST: Admin/Crews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            facade.GetPlatformGateway().Delete(id);

            return RedirectToAction("Index");
        }
    }
}
