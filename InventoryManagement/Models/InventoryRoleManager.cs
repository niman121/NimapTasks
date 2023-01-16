//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Security;
//using InventoryManagement.Services;

//namespace InventoryManagement.Models
//{
//    public class InventoryRoleManager : RoleProvider
//    {
//        public override bool IsUserInRole(string username, string roleName)
//        {
//            throw new NotImplementedException();
//        }

//        public override string[] GetRolesForUser(string username)
//        {
//            var token = HttpContext.Current.Request.Cookies["jwtToken"]?.Value;
//            if (token != null)
//            {
//                var roles = JwtProvider.GetRolesFromJwtToken(token);
//                return roles;
//            }
//            return new []{""};
//        }

//        public override void CreateRole(string roleName)
//        {
//            throw new NotImplementedException();
//        }

//        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
//        {
//            throw new NotImplementedException();
//        }

//        public override bool RoleExists(string roleName)
//        {
//            throw new NotImplementedException();
//        }

//        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
//        {
//            throw new NotImplementedException();
//        }

//        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
//        {
//            throw new NotImplementedException();
//        }

//        public override string[] GetUsersInRole(string roleName)
//        {
//            var token = HttpContext.Current.Request.Cookies["jwtToken"].Value;
//            return new[] { "admin" };

//        }

//        public override string[] GetAllRoles()
//        {
//            throw new NotImplementedException();
//        }

//        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
//        {
//            throw new NotImplementedException();
//        }

//        public override string ApplicationName { get; set; }
//    }
//}