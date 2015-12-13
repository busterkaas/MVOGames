using ServiceGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class GameDetailsViewModel
    {
        public GameDetailsViewModel(ServiceGateway.Models.User user, Game game, List<PlatformGame> platformgames, int? selectedPfId, List<Crew> crews)
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
        public ServiceGateway.Models.User User { get; set; }
        public PlatformGame PlatformGame { get; set; }
        public Game Game { get; set; }
        public List<PlatformGame> PlatformGames { get; set; }
        public List<Crew> MyCrews { get; set; }
    }
}