using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVOGamesDAL;
using MVOGamesDAL.Models;
using MVOGamesUI.Infrastructure;

namespace MVOGamesUI.Areas.User.Controllers
{
    [Authorize(Roles = "user")]
    [SelectedTab("games")]
    public class GamesController : Controller
    {
        // GET: User/Games
        DALFacade facade = new DALFacade();
        public ActionResult Index()
        {
            List <Game> games = facade.GetGameRepository().ReadAll().ToList();
            return View(games);
        }
    }
}