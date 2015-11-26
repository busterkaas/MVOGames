using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVOGamesDAL;
using MVOGamesDAL.Models;
using MVOGamesUI.Infrastructure;
using ServiceGateway;

namespace MVOGamesUI.Areas.User.Controllers
{
    [Authorize(Roles = "user")]
    [SelectedTab("games")]
    public class GamesController : Controller
    {
        // GET: User/Games
        Facade facade = new Facade();
        public ActionResult Index()
        {
            var games = facade.GetGameGateway().GetAll().ToList();
            return View(games);
        }
    }
}