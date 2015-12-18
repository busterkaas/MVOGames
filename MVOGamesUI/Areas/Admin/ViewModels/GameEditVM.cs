
using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.Admin.ViewModels
{
    public class GameEditVM
    {
        private List<PlatformGameDTO> platformgames;
        private List<PlatformDTO> platforms;
        private List<GenreDTO> genres;
        private GameDTO games;

        public GameEditVM( List<PlatformGameDTO> platformgames, List<PlatformDTO> platforms, List<GenreDTO> genres, GameDTO games)
        {
            this.platforms = platforms;
            this.platformgames = platformgames;
            this.genres = genres;
            this.games = games;
        }
        
        public List<PlatformGameDTO> GetPlatformGames()
        {
            return platformgames;
        }

        public List<PlatformDTO> GetPlatforms()
        {
            return platforms;
        }

        public List<GenreDTO> GetGenres()
        {
            return genres;
        }

        public GameDTO GetGames()
        {
            return games;
        }
    }
}