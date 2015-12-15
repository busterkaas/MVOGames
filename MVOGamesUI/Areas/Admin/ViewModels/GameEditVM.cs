using ServiceGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.Admin.ViewModels
{
    public class GameEditVM
    {
        private List<PlatformGame> platformgames;
        private List<Platform> platforms;
        private List<Genre> genres;
        private Game games;

        public GameEditVM( List<PlatformGame> platformgames, List<Platform> platforms, List<Genre> genres, Game games)
        {
            this.platforms = platforms;
            this.platformgames = platformgames;
            this.genres = genres;
            this.games = games;
        }
        
        public List<PlatformGame> GetPlatformGames()
        {
            return platformgames;
        }

        public List<Platform> GetPlatforms()
        {
            return platforms;
        }

        public List<Genre> GetGenres()
        {
            return genres;
        }

        public Game GetGames()
        {
            return games;
        }
    }
}