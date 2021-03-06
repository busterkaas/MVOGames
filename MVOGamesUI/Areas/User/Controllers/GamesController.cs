﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;
using MVOGamesUI.Areas.User.ViewModels;
using MVOGamesUI.Infrastructure;
using ServiceGateway;
using DTOModels.Models;

namespace MVOGamesUI.Areas.User.Controllers
{
    [Authorize(Roles = "user")]
    [SelectedTab("games")]
    public class GamesController : Controller
    {
        // GET: User/Games
        Facade facade = new Facade();
        public ActionResult Index(int? platformId, int? genreId)
        {
            var games = facade.GetGameGateway().GetAll().ToList();
            var genres = facade.GetGenreGateway().GetAll().ToList();
            var platforms = facade.GetPlatformGateway().GetAll().ToList();
           
            if (genreId != null)
            {
                var newGames = from g in games
                           where g.Genres.Any(genre => genre.Id == genreId)
                           select g;
                GamePlatformGenre gpgGenre = new GamePlatformGenre(newGames.ToList(), genres, platforms);
                return View(gpgGenre);
            }
            if (platformId != null)
            {
                var platformGames = facade.GetPlatformGameGateway().GetAll().ToList().Where(p =>p.PlatformId ==platformId);

                var newGames = new List<GameDTO>();
                foreach(var platformGame in platformGames)
                {
                    newGames.Add(platformGame.Game);
                }
                GamePlatformGenre gpgPlatform = new GamePlatformGenre(newGames, genres, platforms);
                return View(gpgPlatform);
                
            }
            GamePlatformGenre gpg = new GamePlatformGenre(games, genres, platforms);
            return View(gpg);
        }

        [HttpPost]
        public ActionResult Index(string search)
        {
            var genres = facade.GetGenreGateway().GetAll().ToList();
            var platforms = facade.GetPlatformGateway().GetAll().ToList();
            var games = facade.GetGameGateway().GetAll().ToList();
            var newGames = games.Where(g => g.Title.ToLower().Contains(search.ToLower()));

            GamePlatformGenre gpg = new GamePlatformGenre(newGames.ToList(), genres, platforms);
            return View(gpg);
        }

        public ActionResult Details(int? id, int? platformId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GameDTO game = facade.GetGameGateway().Get(id);
            
            if (game == null)
            {
                return HttpNotFound();
            }

            var platformgames = facade.GetPlatformGameGateway().GetAll().ToList();
            List<PlatformGameDTO> selectedPfGames = platformgames.Where(p => p.GameId == id).ToList();
            UserDTO user = Auth.user;
            var myCrews = from c in facade.GetCrewGateway().GetAll().ToList()
                            where c.Users.Any(u => u.Id == user.Id)
                            select c;

            GameDetailsViewModel gameDetail = new GameDetailsViewModel(user, game, selectedPfGames, platformId, myCrews.ToList());

            return View(gameDetail);
        }

       
    }
}