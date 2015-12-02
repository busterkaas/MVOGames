using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ServiceGateway;
using ServiceGateway.Models;

namespace MVOGamesUI.Controllers
{
    public class GamesController : Controller
    {
        private Facade facade = new Facade();

        // GET: Games
        public ActionResult Index()
        {
            var games = facade.GetGameGateway().GetAll().ToList();
            return View(games);
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
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
