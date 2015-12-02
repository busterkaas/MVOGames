using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using MVOGamesUI.Areas.User.ViewModels;
using MVOGamesUI.Infrastructure;
using ServiceGateway;
using ServiceGateway.Models;

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
            var genres = facade.GetGenreGateway().GetAll().ToList();
            var platforms = facade.GetPlatformGateway().GetAll().ToList();
            
            GamePlatformGenre gpg = new GamePlatformGenre(games, genres, platforms);
            
            return View(gpg);
        }

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
    }
}