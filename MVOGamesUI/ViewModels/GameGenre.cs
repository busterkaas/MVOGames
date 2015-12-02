using ServiceGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.ViewModels
{
    public class GameGenre
    {
        public List<Game> Games { get; set; }

        public void setGameList(List<Game> games)
        {
            Games = games;
        }

        public List<Genre> Genres { get; set; }

        public void setGenreList(List<Genre> genres)
        {
            Genres = genres;
        }


        public GameGenre()
        {

        }
    }
}