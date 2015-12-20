using BusinessLogic.SearchLogic;
using DTOModels.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicTest.SearchLogicTest
{
    [TestFixture]
    class GameSearchTest
    {
        SearchLogic sl;
        List<GameDTO> games;
        [SetUp]
        public void Setup()
        {
            sl = new SearchLogic();
            games = populateGames();
        }

        [TearDown]
        public void Teardown()
        {

        }

        [Test]
        public void Search_By_Game_Title_Test()
        {
            var gameTitles = sl.GameSearch(games, "2");
            Assert.AreEqual(3, gameTitles.Count());
        }

        [Test]
        public void Search_By_Game_Title1_Test()
        {
            var gameTitles = sl.GameSearch(games, "six");
            Assert.AreNotEqual(3, gameTitles.Count());
        }

        public List<GameDTO> populateGames()
        {
            games = new List<GameDTO>();
            GameDTO gameDTO = new GameDTO() { Id = 1, Title = "GTA 2",ReleaseDate = DateTime.Today, CoverUrl = "test", TrailerUrl = "test", Description= "test" };
            GameDTO gameDTO1 = new GameDTO() { Id = 2, Title = "Rainbow Six - Siege", ReleaseDate = DateTime.Today, CoverUrl = "test", TrailerUrl = "test", Description = "test" };
            GameDTO gameDTO2 = new GameDTO() { Id = 3, Title = "Battlefield 2", ReleaseDate = DateTime.Today, CoverUrl = "test", TrailerUrl = "test", Description = "test" };
            GameDTO gameDTO3 = new GameDTO() { Id = 4, Title = "Overwatch Six", ReleaseDate = DateTime.Today, CoverUrl = "test", TrailerUrl = "test", Description = "test" };
            GameDTO gameDTO4 = new GameDTO() { Id = 5, Title = "Diablo III: Reaper of Souls", ReleaseDate = DateTime.Today, CoverUrl = "test", TrailerUrl = "test", Description = "test" };
            GameDTO gameDTO5 = new GameDTO() { Id = 6, Title = "Need for Speed", ReleaseDate = DateTime.Today, CoverUrl = "test", TrailerUrl = "test", Description = "test" };
            GameDTO gameDTO6 = new GameDTO() { Id = 7, Title = "Forza Horizon 2", ReleaseDate = DateTime.Today, CoverUrl = "test", TrailerUrl = "test", Description = "test" };

            games.Add(gameDTO);
            games.Add(gameDTO1);
            games.Add(gameDTO2);
            games.Add(gameDTO3);
            games.Add(gameDTO4);
            games.Add(gameDTO5);
            games.Add(gameDTO6);

            return games;
        }
    }
}
