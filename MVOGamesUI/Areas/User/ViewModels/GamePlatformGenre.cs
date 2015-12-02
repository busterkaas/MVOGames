using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceGateway.Models;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class GamePlatformGenre
    {
        public GamePlatformGenre(List<Game> games, List<Genre> genres, List<Platform> platforms)
        {
            Games = games;
            Genres = genres;
            Platforms = platforms;
        }
        public List<Game> Games { get; set; }
        //public void setGameList(List<Game> games)
        //{
        //    Games = games;
        //}
        public List<Genre> Genres { get; set; }
        //public void setGenreList(List<Genre> genres)
        //{
        //    Genres = genres;
        //}
        public List<Platform> Platforms { get; set; }
        //public void setPlatformList(List<Platform> platforms)
        //{
        //    Platforms = platforms;
        //}
    }
}