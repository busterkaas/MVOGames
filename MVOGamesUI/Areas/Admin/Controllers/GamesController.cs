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
using System.Net.Http;
using BusinessLogic.SearchLogic;
using MVOGamesUI.Areas.Admin.ViewModels;

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
            ViewBag.Genres = new SelectList(facade.GetGenreGateway().GetAll(), "Id", "Name");
            return View();
        }

        // POST: Admin/Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ReleaseDate,CoverUrl,TrailerUrl,Description")] Game game, int[] Genres)
        {
            if (ModelState.IsValid)
            {
                List<Genre> NewGenres = new List<Genre>();
                foreach (var genreID in Genres)
                {
                    NewGenres.Add(new Genre() { Id = genreID });
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
           
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Game game = facade.GetGameGateway().Get(id);
            //if (game == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(game);

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            Game game = facade.GetGameGateway().Get(id);
            List<PlatformGame> platformGames = facade.GetPlatformGameGateway().GetAll().Where(o => o.GameId == game.Id).ToList();
            List<Platform> platforms = new List<Platform>();
            List<Genre> genres = new List<Genre>();

            foreach (var p in platformGames)
            {
                platforms.Add(facade.GetPlatformGateway().Get(p.PlatformId));
            }
            foreach (var g in game.Genres)
            {
                genres.Add(facade.GetGenreGateway().Get(g.Id));
            }
            GameEditVM gEditVM = new GameEditVM(platformGames, platforms, genres, game);
            ViewBag.Genres = new SelectList(genres, "Id", "Name");
            return View(gEditVM);
        }

        // POST: Admin/Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,ReleaseDate,CoverUrl,TrailerUrl,Description")] Game game, int[] Genres)
        {
            
            if (ModelState.IsValid)
            {
                List<Genre> NewGenres = new List<Genre>();
                foreach (var genreID in Genres)
                {
                    NewGenres.Add(new Genre() { Id = genreID });
                }
                game.Genres = NewGenres;
                facade.GetGameGateway().Update(game);
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Admin/Games/Delete/5
        public ActionResult Delete(int? id)
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

        public IEnumerable<Game> GetGameSearch(string input)
        {
            IEnumerable<Game> games = sl.GameSearch(facade.GetGameGateway().GetAll(), input);
            return games;
        }
    }
}
