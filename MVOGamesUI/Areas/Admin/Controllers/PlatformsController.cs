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
    [SelectedTab("platforms")]
    public class PlatformsController : Controller
    {
        private Facade facade = new Facade();
        // GET: Admin/Platforms
        public ActionResult Index()
        {
            var platforms = facade.GetPlatformGateway().GetAll();
            return View(platforms);
        }

        // GET: Admin/Platforms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platform platform = facade.GetPlatformGateway().Get(id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            return View(platform);
        }

        // GET: Admin/Platforms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Platforms/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Platform platform)
        {
            if (ModelState.IsValid)
            {
                facade.GetPlatformGateway().Create(platform);

                return RedirectToAction("Index");
            }
            return View(platform);
        }

        // GET: Admin/Platforms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platform platform = facade.GetPlatformGateway().Get(id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            return View(platform);
        }

        // POST: Admin/Platforms/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Platform platform)
        {
            if (ModelState.IsValid)
            {
                facade.GetPlatformGateway().Update(platform);

                return RedirectToAction("Index");
            }
            return View(platform);
        }

        // GET: Admin/Platforms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Platform platform = facade.GetPlatformGateway().Get(id);
            if (platform == null)
            {
                return HttpNotFound();
            }
            return View(platform);
        }

        // POST: Admin/Platforms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            facade.GetPlatformGateway().Delete(id);

            return RedirectToAction("Index");
        }
    }
}
