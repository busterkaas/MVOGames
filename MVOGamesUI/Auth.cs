using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVOGamesDAL;
using MVOGamesDAL.Models;

namespace MVOGamesUI
{
    public static class Auth
    {
        private const string UserKey = "MVOGamesUI.Auth.UserKey";

        public static User user
        {
            
            get
            {
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    return null;
                }

                var user = HttpContext.Current.Items[UserKey] as User;
                if (user == null)
                {
                    DALFacade df = new DALFacade();

                    user = df.GetUserRepository().FindByUsername(HttpContext.Current.User.Identity.Name);
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