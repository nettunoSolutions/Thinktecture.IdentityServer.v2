using Sagrada.IdentityServer.Module.Configuration;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.Linq;
using System.Web.Security;
using Thinktecture.IdentityServer;
using Thinktecture.IdentityServer.Repositories;

namespace Sagrada.IdentityServer.Module.Repositories
{
    public class SagradaProviderUserRepository : IUserRepository
    {
        private const string ADMIN_CONFIG_KEY = "sagradaAdminSection";
        private AdminSection configuration;

        [Import]
        public IClientCertificatesRepository Repository { get; set; }

        public SagradaProviderUserRepository()
        {
            Container.Current.SatisfyImportsOnce(this);
            configuration = ConfigurationManager.GetSection(ADMIN_CONFIG_KEY) as AdminSection;
            if (configuration == null)
                throw new ConfigurationException("AdminSection not found!!!");
        }

        public bool ValidateUser(string userName, string password)
        {
            return Membership.ValidateUser(SetDefaultDomain(userName), password);
        }

        /// <summary>
        /// in base al provider di Memership formatta la string dello
        /// user name. Es: per quello di ActiveDirectoryMembershipProvider
        /// aggiunge il dominio qualora non fosse stato specificato
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        private string SetDefaultDomain(string userName)
        {
            string formattedUserName = userName;
            //TODO Add @domain to username
            if (Membership.Provider.GetType() == typeof(ActiveDirectoryMembershipProvider) && !string.IsNullOrEmpty(configuration.Domain))
            {
                if (!formattedUserName.EndsWith("@" + configuration.Domain) && !formattedUserName.Contains("@"))
                {   //il secondo controllo è un grossolano modo per controllare che non abbia già un dominio nella username
                    formattedUserName += "@" + configuration.Domain;
                }
            }

            return formattedUserName;
        }

        public bool ValidateUser(System.Security.Cryptography.X509Certificates.X509Certificate2 clientCertificate, out string userName)
        {
            //TODO Add @domain to username
            return Repository.TryGetUserNameFromThumbprint(clientCertificate, out userName);
        }

        public IEnumerable<string> GetRoles(string userName)
        {
            var returnedRoles = new List<string>();

            if (Roles.Enabled)
            {
                var roles = Roles.GetRolesForUser(userName);
                returnedRoles.AddRange(roles);
                // = roles.Where(role => role.StartsWith(Constants.Roles.InternalRolesPrefix)).ToList();
            }

            foreach (var item in configuration.Users.OfType<UserElement>())
            {
                if (SetDefaultDomain(userName) == SetDefaultDomain(item.Name))
                    returnedRoles.Add(Constants.Roles.IdentityServerAdministrators);
            }

            return returnedRoles;
        }

    }
}
