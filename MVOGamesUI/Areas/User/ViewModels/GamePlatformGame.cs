using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceGateway.Models;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class GamePlatformGame
    {
        public GamePlatformGame(Game game, List<PlatformGame> platformgames)
        {
            Game = game;
            PlatformGames = platformgames;
        }
        public Game Game { get; set; }
        public List<PlatformGame> PlatformGames { get; set; }
    }
}