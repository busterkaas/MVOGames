﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVOGamesUI.Infrastructure;
using ServiceGateway;
using DTOModels.Models;

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

        // GET: Admin/Crews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Crews/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CrewImgUrl,CrewLeaderId")] CrewDTO crew)
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
            CrewDTO crew = facade.GetCrewGateway().Get(id);
            
            if (crew == null)
            {
                return HttpNotFound();
            }
            return View(crew);
        }

        // POST: Admin/Crews/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CrewImgUrl,CrewLeaderId, Users")] CrewDTO crew)
        {
            if (ModelState.IsValid)
            {
                facade.GetCrewGateway().Update(crew);
                return RedirectToAction("Index");
            }
            crew = facade.GetCrewGateway().Get(crew.Id);
            return View(crew);
        }

        // GET: Admin/Crews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CrewDTO crew = facade.GetCrewGateway().Get(id);
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
            CrewDTO crew = facade.GetCrewGateway().Get(crewId);
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

            facade.GetCrewGateway().Delete(id);

            return RedirectToAction("Index");
        }
    }
}
