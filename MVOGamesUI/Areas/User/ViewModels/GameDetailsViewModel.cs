
using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class GameDetailsViewModel
    {
        public GameDetailsViewModel(UserDTO user, GameDTO game, List<PlatformGameDTO> platformgames, int? selectedPfId, List<CrewDTO> crews)
        {
            Game = game;
            PlatformGames = platformgames;
            MyCrews = crews;
            setSelectedPlatform(selectedPfId);

        }

        public void setSelectedPlatform(int? pfId)
        {
            if (pfId != null)
            {
                PlatformGame = PlatformGames.Find(pg => pg.PlatformId == pfId);
            }
        }
        public UserDTO User { get; set; }
        public PlatformGameDTO PlatformGame { get; set; }
        public GameDTO Game { get; set; }
        public List<PlatformGameDTO> PlatformGames { get; set; }
        public List<CrewDTO> MyCrews { get; set; }
    }
}