using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class GamePlatformGenre
    {
        public GamePlatformGenre(List<GameDTO> games, List<GenreDTO> genres, List<PlatformDTO> platforms)
        {
            Games = games;
            Genres = genres;
            Platforms = platforms;
        }
        public List<GameDTO> Games { get; set; }
        public List<GenreDTO> Genres { get; set; }
        public List<PlatformDTO> Platforms { get; set; }
    }
}