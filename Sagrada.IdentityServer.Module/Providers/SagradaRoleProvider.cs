using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using Thinktecture.IdentityServer.Repositories;

namespace Sagrada.IdentityServer.Module.Providers
{
    /// <summary>
    /// Basic Role
    /// TODO Extend...may be
    /// </summary>
    public class SagradaRoleProvider : RoleProvider
    {
        [Import]
        public ISagradaIdentityService SagradaIdentityService { get; set; }

        public SagradaRoleProvider()
        {
            Container.Current.SatisfyImportsOnce(this);
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get;
            set;
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

        public override string[] GetRolesForUser(string username)
        {
            return SagradaIdentityService.GetRoles(username);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            return SagradaIdentityService.GetRoles(username).Any(p=>roleName == p);
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
