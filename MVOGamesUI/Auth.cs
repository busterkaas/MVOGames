using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceGateway;
using DTOModels.Models;

namespace MVOGamesUI
{
    public static class Auth
    {
        private const string UserKey = "MVOGamesUI.Auth.UserKey";

        public static UserDTO user
        {
            
            get
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    return null;
                }

                var user = HttpContext.Current.Items[UserKey] as UserDTO;
                if (user == null)
                {
                    Facade facade = new Facade();
                    List<UserDTO> users = facade.GetUserGateway().GetAll().ToList();
                    string username = HttpContext.Current.User.Identity.Name;
                    user = users.First(u => u.Username == username);

                    if (user == null)
                    {
                        return null;
                    }
                    HttpContext.Current.Items[UserKey] = user;
                }
                return user;
            }
        }
    }
}