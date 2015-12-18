using DTOModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Areas.Admin.ViewModels
{
    public class RolesUser
    {
        private UserDTO user;
        private List<RoleDTO> roles;

        public RolesUser(UserDTO user, List<RoleDTO> roles)
        {
            this.user = user;
            this.roles = roles;
        }

        public UserDTO GetUser()
        {
            return user;
        }

        public List<RoleDTO> GetRoles()
        {
            return roles;
        }
    }
}