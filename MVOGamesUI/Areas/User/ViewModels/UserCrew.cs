using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceGateway.Models;

namespace MVOGamesUI.Areas.User.ViewModels
{
    public class UserCrew
    {
        public UserCrew(ServiceGateway.Models.User user, List<Crew> crews)
        {
            User = user;
            Crews = crews;
        }
        public ServiceGateway.Models.User User { get; set; }
        public List<Crew> Crews { get; set; }
       
    }
}