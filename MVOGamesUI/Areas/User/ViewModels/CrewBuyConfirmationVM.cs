using ServiceGateway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class CrewBuyConfirmationVM
    {
        public CrewBuyConfirmationVM(ServiceGateway.Models.User user, PlatformGame platformGame, Crew crew)
        {
            User = user;
            PlatformGame = platformGame;
            Crew = crew;
        }
        public ServiceGateway.Models.User User { get; set; }
        public PlatformGame PlatformGame { get; set; }
        public Crew Crew { get; set; }
    }
}