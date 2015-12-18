
using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class CrewBuyConfirmationVM
    {
        public CrewBuyConfirmationVM(UserDTO user, PlatformGameDTO platformGame, CrewDTO crew)
        {
            User = user;
            PlatformGame = platformGame;
            Crew = crew;
        }
        public UserDTO User { get; set; }
        public PlatformGameDTO PlatformGame { get; set; }
        public CrewDTO Crew { get; set; }
    }
}