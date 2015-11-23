using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MVOGamesDAL.Models;
using MVOGamesDAL;

namespace MVOGamesTestDAL
{
    [TestFixture]
    class GameRepositoryTest
    {
        DALFacade facade;
        [SetUp]
        public void SetUp()
        {
            facade = new DALFacade();
           MVOGamesDAL.Context.DBInitializer.Initialize();

        }

        [TearDown]
        public void TearDown()
        {
            facade = null;
        }
        [Test]
        public void Game_Added_To_DB_Test()
        {
            Genre genre = new Genre {Name = "Junglegame"};
            Game game = new Game
            {
                Title = "Game",
                CoverUrl = "coverurl",
                TrailerUrl = "trailerurl",
                Description = "desc",
                Genres = new List<Genre>() {genre},
                Price = 10,
                ReleaseDate = DateTime.Now
            };

            facade.GetGameRepository().Add(game);
            List<Game> games = facade.GetGameRepository().ReadAll().ToList();

            Game searchGame = new Game();
            foreach (Game g in games)
            {
                if (g.Title == "Game")
                {
                    searchGame = g;
                }
            }

            Assert.AreEqual(game.Genres, searchGame.Genres);
        }
    }
}
