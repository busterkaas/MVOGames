using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVOGamesUI.Infrastructure
{
    public class RoleProvider : System.Web.Security.RoleProvider
    {

        public override string[] GetRolesForUser(string username)
        {
            var role = new string[] {Auth.user.Role.RoleName};
            return role;
            //if (username == "buster")
            //{
            //    return new[] { "admin" };
            //}
            //else if (username == "shane")
            //{
            //    return new[] {"user"};
            //}
            //return new string[] {};

        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }


        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}