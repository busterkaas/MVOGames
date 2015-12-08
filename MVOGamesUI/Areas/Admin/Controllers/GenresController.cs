using MVOGamesUI.Infrastructure;
using ServiceGateway;
using ServiceGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVOGamesUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [SelectedTab("genres")]
    public class GenresController : Controller
    {
        private Facade facade = new Facade();
        // GET: Admin/Genres
        public ActionResult Index()
        {
            var genres = facade.GetGenreGateway().GetAll();
            return View(genres);
        }

        // GET: Admin/Genres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Genres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                facade.GetGenreGateway().Create(genre);

                return RedirectToAction("Index");
            }
            return View(genre);
        }

        // GET: Admin/Genres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = facade.GetGenreGateway().Get(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Admin/Genres/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Name")] Genre genre)
        {
            if (ModelState.IsValid)
            {
                facade.GetGenreGateway().Update(genre);

                return RedirectToAction("Index");
            }
            return View(genre);
        }

        // GET: Admin/Genres/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Genre genre = facade.GetGenreGateway().Get(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Admin/Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            facade.GetGenreGateway().Delete(id);

            return RedirectToAction("Index");
        }
    }
}
