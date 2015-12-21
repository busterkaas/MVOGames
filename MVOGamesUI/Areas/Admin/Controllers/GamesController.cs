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
using System.Net.Http;
using BusinessLogic.SearchLogic;
using MVOGamesUI.Areas.Admin.ViewModels;
using DTOModels.Models;

namespace MVOGamesUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    [SelectedTab("games")]
    public class GamesController : Controller
    {
        private Facade facade = new Facade();
        SearchLogic sl = new SearchLogic();

        // GET: Admin/Games
        public ActionResult Index(string GenreList, string search)
        {
            var games = facade.GetGameGateway().GetAll();
            ViewBag.GenreList = new SelectList(facade.GetGenreGateway().GetAll().OrderBy(g => g.Name).Select(g => g.Name));

            if (string.IsNullOrEmpty(GenreList) && string.IsNullOrEmpty(search))
                return View(games);
            else
            {
                var genreGames = from a in games.ToList()
                                 where a.Genres.Any(g => g.Name == GenreList)
                                 select a;

                return View(genreGames);
            }
        }

        // GET: Admin/Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameDTO game = facade.GetGameGateway().Get(id);
            List<PlatformGameDTO> platformGames = facade.GetPlatformGameGateway().GetAll().Where(o => o.GameId == game.Id).ToList();
            List<PlatformDTO> platforms = new List<PlatformDTO>();
            List<GenreDTO> genres = new List<GenreDTO>();

            foreach (var p in platformGames)
            {
                platforms.Add(facade.GetPlatformGateway().Get(p.PlatformId));
            }
            foreach (var g in game.Genres)
            {
                genres.Add(facade.GetGenreGateway().Get(g.Id));
            }
            GameEditVM gEditVM = new GameEditVM(platformGames, platforms, genres, game);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(gEditVM);
        }

        // GET: Admin/Games/Create
        public ActionResult Create()
        {
            ViewBag.Platforms = new SelectList(facade.GetPlatformGateway().GetAll(), "Id", "Name");
            ViewBag.Genres = new SelectList(facade.GetGenreGateway().GetAll(), "Id", "Name");
            return View();
        }

        // POST: Admin/Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ReleaseDate,CoverUrl,TrailerUrl,Description")] GameDTO game, int[] Genres)
        {
            if (ModelState.IsValid)
            {
                List<GenreDTO> NewGenres = new List<GenreDTO>();
                foreach (var genreID in Genres)
                {
                    NewGenres.Add(new GenreDTO() { Id = genreID });
                }
                game.Genres = NewGenres;
                HttpResponseMessage response = facade.GetGameGateway().Create(game);
                if(response.StatusCode == HttpStatusCode.Created)
                return RedirectToAction("Index");
                else
                {
                    return new HttpStatusCodeResult(response.StatusCode);
                }
            }
            
            return View(game);
            
        }

        // GET: Admin/Games/Edit/5
        public ActionResult Edit(int? id)
        {
            GameDTO game = facade.GetGameGateway().Get(id);
            List<PlatformGameDTO> platformGames = facade.GetPlatformGameGateway().GetAll().Where(o => o.GameId == game.Id).ToList();
            List<PlatformDTO> platforms = new List<PlatformDTO>();
            List<GenreDTO> genres = new List<GenreDTO>();

            foreach (var p in platformGames)
            {
                platforms.Add(facade.GetPlatformGateway().Get(p.PlatformId));
            }
            foreach (var g in game.Genres)
            {
                genres.Add(facade.GetGenreGateway().Get(g.Id));
            }
            GameEditVM gEditVM = new GameEditVM(platformGames, platforms, genres, game);
            ViewBag.Genres = new SelectList(facade.GetGenreGateway().GetAll(), "Id", "Name");
            return View(gEditVM);
        }

        // POST: Admin/Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ReleaseDate,CoverUrl,TrailerUrl,Description")] GameDTO game, int[] Genres)
        {

            if (!ModelState.IsValid)
            {
                List<PlatformGameDTO> platformGames = facade.GetPlatformGameGateway().GetAll().Where(o => o.GameId == game.Id).ToList();
                List<PlatformDTO> platforms = new List<PlatformDTO>();
                List<GenreDTO> genres = new List<GenreDTO>();

                foreach (var p in platformGames)
                {
                    platforms.Add(facade.GetPlatformGateway().Get(p.PlatformId));
                }
                foreach (var g in game.Genres)
                {
                    genres.Add(facade.GetGenreGateway().Get(g.Id));
                }
                GameEditVM gEditVM = new GameEditVM(platformGames, platforms, genres, game);
                ViewBag.Genres = new SelectList(facade.GetGenreGateway().GetAll(), "Id", "Name");
                return View(gEditVM);
            }
            List<GenreDTO> NewGenres = new List<GenreDTO>();
            foreach (var genreID in Genres)
            {
                NewGenres.Add(new GenreDTO() { Id = genreID });
            }
            game.Genres = NewGenres;
            facade.GetGameGateway().Update(game);
            return RedirectToAction("Index");
        }

        // GET: Admin/Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameDTO game = facade.GetGameGateway().Get(id);
            List<PlatformGameDTO> platformGames = facade.GetPlatformGameGateway().GetAll().Where(o => o.GameId == game.Id).ToList();
            List<PlatformDTO> platforms = new List<PlatformDTO>();
            List<GenreDTO> genres = new List<GenreDTO>();

            foreach (var p in platformGames)
            {
                platforms.Add(facade.GetPlatformGateway().Get(p.PlatformId));
            }
            foreach (var g in game.Genres)
            {
                genres.Add(facade.GetGenreGateway().Get(g.Id));
            }
            GameEditVM gEditVM = new GameEditVM(platformGames, platforms, genres, game);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(gEditVM);
        }

        // POST: Admin/Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            facade.GetGameGateway().Delete(id);

            return RedirectToAction("Index");
        }
        // GET: Admin/Game/CreatePlatformToGame/5
        public ActionResult CreatePlatformToGame(int gameId)
        {
            ViewBag.Platforms = new SelectList(facade.GetPlatformGateway().GetAll().OrderBy(g => g.Name), "Id", "Name");
            var platformGame = new PlatformGameDTO() {GameId = gameId };
            return View(platformGame);
        }

        // POST: Admin/Game/CreatePlatformToGame/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePlatformToGame([Bind(Include = "Id,GameId,PlatformId,Price,Stock")] PlatformGameDTO platformGame)
        {
            var platformGames = facade.GetPlatformGameGateway().GetAll().Where(g => g.GameId == platformGame.GameId);
            foreach(var pg in platformGames)
            {
                if(pg.PlatformId == platformGame.PlatformId)
                {
                    ViewBag.Platforms = new SelectList(facade.GetPlatformGateway().GetAll().OrderBy(g => g.Name), "Id", "Name");
                    ViewBag.Error = "Platformgame already exists";
                    return View(platformGame);
                }
            }
            if (platformGame == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            platformGame.Game = facade.GetGameGateway().Get(platformGame.GameId);
            platformGame.Platform = facade.GetPlatformGateway().Get(platformGame.PlatformId);

            facade.GetPlatformGameGateway().Create(platformGame);

            return RedirectToAction("Edit" + "/" + platformGame.GameId);
        }

        // GET: Admin/Game/EditPlatformGame/5
        public ActionResult EditPlatformFromGame(int? id)
        {
            PlatformGameDTO platformGame = facade.GetPlatformGameGateway().Get(id);
            return View(platformGame);
        }

        //POST: Admin/Game/EditPlatformGame/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPlatformFromGame([Bind(Include = "Id,GameId,PlatformId,Price,Stock")] PlatformGameDTO platformGame)
        {
            platformGame.Game = facade.GetGameGateway().Get(platformGame.GameId);
            platformGame.Platform = facade.GetPlatformGateway().Get(platformGame.PlatformId);

            facade.GetPlatformGameGateway().Update(platformGame);
            return RedirectToAction("Edit" + "/" + platformGame.GameId);
        }

        public ActionResult DeletePlatformFromGame(int? id, int? gameId)
        {
            if (id == null || gameId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameDTO game = facade.GetGameGateway().Get(gameId);
            if (game == null)
            {
                return HttpNotFound();
            }
            facade.GetPlatformGameGateway().Delete(id);
            return RedirectToAction("Edit" + "/" + gameId);
        }

        public IEnumerable<GameDTO> GetGameSearch(string input)
        {
            IEnumerable<GameDTO> games = sl.GameSearch(facade.GetGameGateway().GetAll(), input);
            return games;
        }
    }
}
