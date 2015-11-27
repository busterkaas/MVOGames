using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
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
    [SelectedTab("games")]
    public class GamesController : Controller
    {
        private Facade facade = new Facade();

        // GET: Admin/Games
        public ActionResult Index()
        {
            var games = facade.GetGameGateway().GetAll().ToList();
            return View(games);
        }

        // GET: Admin/Games/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = facade.GetGameGateway().Get(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Admin/Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ReleaseDate,Price,CoverUrl,TrailerUrl,Description")] Game game)
        {
            if (ModelState.IsValid)
            {
                facade.GetGameGateway().Create(game);
               
                return RedirectToAction("Index");
            }

            return View(game);
        }

        // GET: Admin/Games/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = facade.GetGameGateway().Get(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Admin/Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ReleaseDate,Price,CoverUrl,TrailerUrl,Description")] Game game)
        {
            if (ModelState.IsValid)
            {
                facade.GetGameGateway().Update(game);
                
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Admin/Games/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = facade.GetGameGateway().Get(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Admin/Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            facade.GetGameGateway().Delete(id);
      
            return RedirectToAction("Index");
        }

    }
}
