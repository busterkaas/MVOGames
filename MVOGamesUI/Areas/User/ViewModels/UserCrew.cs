using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class UserCrew
    {
        public UserCrew(UserDTO user, List<CrewDTO> crews)
        {
            User = user;
            Crews = crews;
        }
        public UserDTO User { get; set; }
        public List<CrewDTO> Crews { get; set; }
       
    }
}