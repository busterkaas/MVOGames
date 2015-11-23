using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVOGamesDAL.Models;

namespace MVOGamesUI.Areas.Admin.ViewModels
{
    public class RolesUser
    {
        private MVOGamesDAL.Models.User user;
        private List<Role> roles;

        public RolesUser(MVOGamesDAL.Models.User user, List<Role> roles)
        {
            this.user = user;
            this.roles = roles;
        }

        public MVOGamesDAL.Models.User GetUser()
        {
            return user;
        }

        public List<Role> GetRoles()
        {
            return roles;
        }
    }
}