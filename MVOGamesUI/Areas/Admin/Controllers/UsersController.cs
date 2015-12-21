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
using BusinessLogic.SearchLogic;
using DTOModels.Models;

namespace MVOGamesUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [SelectedTab("users")]
    public class UsersController : Controller
    {
        private Facade facade = new Facade();
        SearchLogic sl = new SearchLogic();

        // GET: Admin/Users
        public ActionResult Index(string search)
        {
            List<UserDTO> users = facade.GetUserGateway().GetAll().ToList();

            if (string.IsNullOrEmpty(search))
                return View(users);
            else
            {
                return View(GetUserSearch(search));
            }
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO user = facade.GetUserGateway().Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            UserDTO u = new UserDTO();
            List<RoleDTO> roles = facade.GetRoleGateway().GetAll().ToList();
            RolesUser ru = new RolesUser(u, roles);
            return View(ru);
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,PasswordHash,FirstName,LastName,StreetName,HouseNr,ZipCode,City,Email")] UserDTO user)
        {
            if (ModelState.IsValid)
            {
                user.SetPassword(user.PasswordHash);
                //get user role and set it for the new user
                RoleDTO role = facade.GetRoleGateway().Get(2);
                user.Role = role;
                facade.GetUserGateway().Create(user);
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
            UserDTO user = facade.GetUserGateway().Get(id);
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
        public ActionResult Edit([Bind(Include = "Id,Username,PasswordHash,FirstName,LastName,StreetName,HouseNr,ZipCode,City,Email, RoleId")] UserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            if(user.ZipCode < 1)
            {
                ModelState.AddModelError("ZipCode", "ZipCode must be atleast 1");
                return View(user);
            }
            var newUser = facade.GetUserGateway().Get(user.Id);
            newUser.Username = user.Username;
            newUser.PasswordHash = user.PasswordHash;
            newUser.FirstName = user.FirstName;
            newUser.LastName = user.LastName;
            newUser.StreetName = user.StreetName;
            newUser.HouseNr = user.HouseNr;
            newUser.ZipCode = user.ZipCode;
            newUser.City = user.City;
            newUser.Email = user.Email;

            facade.GetUserGateway().Update(newUser);
            return RedirectToAction("Index");
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDTO user = facade.GetUserGateway().Get(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            UserDTO user = facade.GetUserGateway().Get(id);
            facade.GetUserGateway().Delete(id);
            return RedirectToAction("Index");
        }


        public IEnumerable<UserDTO> GetUserSearch(string input)
        {
            IEnumerable<UserDTO> users = sl.UserSearch(facade.GetUserGateway().GetAll(), input);
            return users;
        }
    }
}
