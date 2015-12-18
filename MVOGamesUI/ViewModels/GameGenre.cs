using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.ViewModels
{
    public class GameGenre
    {
        public List<GameDTO> Games { get; set; }

        public void setGameList(List<GameDTO> games)
        {
            Games = games;
        }

        public List<GenreDTO> Genres { get; set; }

        public void setGenreList(List<GenreDTO> genres)
        {
            Genres = genres;
        }


        public GameGenre()
        {

        }
    }
}