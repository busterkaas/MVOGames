using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceGateway.Models;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class GamePlatformGame
    {
        public GamePlatformGame(Game game, List<PlatformGame> platformgames, int? selectedPfId)
        {
            Game = game;
            PlatformGames = platformgames;
            setSelectedPlatform(selectedPfId);

        }

        public void setSelectedPlatform(int? pfId)
        {
            if (pfId != null)
            {
                PlatformGame = PlatformGames.Find(pg => pg.PlatformId == pfId);
            }
        }
        public PlatformGame PlatformGame { get; set; }
        public Game Game { get; set; }
        public List<PlatformGame> PlatformGames { get; set; }
    }
}