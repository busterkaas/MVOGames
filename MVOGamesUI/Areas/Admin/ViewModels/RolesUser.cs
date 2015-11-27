using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceGateway.Models;

namespace MVOGamesUI.Areas.Admin.ViewModels
{
    public class RolesUser
    {
        private ServiceGateway.Models.User user;
        private List<Role> roles;

        public RolesUser(ServiceGateway.Models.User user, List<Role> roles)
        {
            this.user = user;
            this.roles = roles;
        }

        public ServiceGateway.Models.User GetUser()
        {
            return user;
        }

        public List<Role> GetRoles()
        {
            return roles;
        }
    }
}