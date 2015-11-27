using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVOGamesUI.Areas.Admin.ViewModels;
using MVOGamesUI.Infrastructure;
using ServiceGateway;
using ServiceGateway.Models;

namespace MVOGamesUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [SelectedTab("users")]
    public class UsersController : Controller
    {
        private Facade facade = new Facade();

        // GET: Admin/Users
        public ActionResult Index()
        {
            List<ServiceGateway.Models.User> users = facade.GetUserGateway().GetAll().ToList();
            return View(users);
            //return View(facade.GetUserRepository().ReadAll().ToList());
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceGateway.Models.User user = facade.GetUserGateway().Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            ServiceGateway.Models.User u = new ServiceGateway.Models.User();
            List<Role> roles = facade.GetRoleGateway().GetAll().ToList();
            RolesUser ru = new RolesUser(u, roles);
            return View(ru);
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password,FirstName,LastName,StreetName,HouseNr,ZipCode,City,Email")] ServiceGateway.Models.User user)
        {
            if (ModelState.IsValid)
            {
                facade.GetUserGateway().Create(user);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceGateway.Models.User user = facade.GetUserGateway().Get(id);
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
        public ActionResult Edit([Bind(Include = "Id,Username,Password,FirstName,LastName,StreetName,HouseNr,ZipCode,City,Email")] ServiceGateway.Models.User user)
        {
            if (ModelState.IsValid)
            {
                facade.GetUserGateway().Update(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceGateway.Models.User user = facade.GetUserGateway().Get(id);
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
            ServiceGateway.Models.User user = facade.GetUserGateway().Get(id);
            facade.GetUserGateway().Delete(id);
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
