using Sagrada.IdentityServer.Module.SagradaService;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Thinktecture.IdentityServer;

namespace Sagrada.IdentityServer.Module.Repositories
{
    public class SagradaIdentityService : ISagradaIdentityService
    {
        private IdentityUserServiceClient proxyClient;

        public SagradaIdentityService()
        {
            proxyClient = new IdentityUserServiceClient();
        }

        public IEnumerable<Tuple<Guid, string>> GetProfiles(string userName)
        {
            try
            {
                return from c in proxyClient.GetProfiles(userName)
                       select new Tuple<Guid, string>(c.Id, c.Description);
            }
            catch (Exception ex)
            {
                //swallow exception return empty list
                Tracing.Error(ex.Message);
            }

            return new List<Tuple<Guid, string>>();
        }

        public IEnumerable<Tuple<Guid, string>> GetCompanies()
        {
            try
            {

                return from c in proxyClient.GetCompanies()
                       select new Tuple<Guid, string>(c.Id, c.Description);
            }
            catch (Exception ex)
            {
                //swallow exception return empty list
                Tracing.Error(ex.Message);
            }
            return new List<Tuple<Guid, string>>();
        }

        public IEnumerable<System.Globalization.CultureInfo> GetLanguages()
        {
            try
            {
                return proxyClient.GetLanguages().Select(x => new CultureInfo(x.Name)).ToArray();
            }
            catch (Exception ex)
            {
                //swallow exception return empty list
                Tracing.Error(ex.Message);
            }
            return new CultureInfo[0];
            
        }


        public string[] GetRoles(string userName)
        {
            try
            {
                return proxyClient.GetRoles(userName);
            }
            catch (Exception ex)
            {
                //swallow exception return empty list
                Tracing.Error(ex.Message);
            }
            return new string[0];
        }
    }
}
