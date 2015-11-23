using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVOGamesDAL;
using MVOGamesDAL.Context;
using MVOGamesDAL.Models;
using MVOGamesUI.Areas.Admin.ViewModels;
using MVOGamesUI.Infrastructure;

namespace MVOGamesUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [SelectedTab("users")]
    public class UsersController : Controller
    {
        private DALFacade facade = new DALFacade();

        // GET: Admin/Users
        public ActionResult Index()
        {
            List<MVOGamesDAL.Models.User> users= facade.GetUserRepository().ReadAll().ToList();
            return View(users);
            //return View(facade.GetUserRepository().ReadAll().ToList());
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVOGamesDAL.Models.User user = facade.GetUserRepository().Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            MVOGamesDAL.Models.User u = new MVOGamesDAL.Models.User();
            List<Role> roles = facade.GetRoleRepository().ReadAll().ToList();
            RolesUser ru = new RolesUser(u, roles);
            return View(ru);
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password,FirstName,LastName,StreetName,HouseNr,ZipCode,City,Email")] MVOGamesDAL.Models.User user)
        {
            if (ModelState.IsValid)
            {
                facade.GetUserRepository().Add(user);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVOGamesDAL.Models.User user = facade.GetUserRepository().Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Password,FirstName,LastName,StreetName,HouseNr,ZipCode,City,Email")] MVOGamesDAL.Models.User user)
        {
            if (ModelState.IsValid)
            {
                facade.GetUserRepository().Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MVOGamesDAL.Models.User user = facade.GetUserRepository().Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MVOGamesDAL.Models.User user = facade.GetUserRepository().Find(id);
            facade.GetUserRepository().Delete(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
