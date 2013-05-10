using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.Linq;
using System.Security.Claims;
using System.Web.Profile;
using System.Web.Security;
using Thinktecture.IdentityServer;
using Thinktecture.IdentityServer.Repositories;
using Thinktecture.IdentityServer.TokenService;

namespace Sagrada.IdentityServer.Module.Repositories
{
    /// <summary>
    /// Claim Repository custom per sagrada
    /// </summary>
    public class SagradaProviderClaimsRepository : IClaimsRepository
    {
        private const string ProfileClaimPrefix = "http://nettunosolutions.com/identity/claims/profileclaims/";

        [Import]
        public ISagradaIdentityService SagradaIdentityService { get; set; }

        public SagradaProviderClaimsRepository()
        {
            Container.Current.SatisfyImportsOnce(this);
        }

        public IEnumerable<Claim> GetClaims(ClaimsPrincipal principal, RequestDetails requestDetails)
        {
            var userName = principal.Identity.Name;
            var claims = new List<Claim>(from c in principal.Claims select c);

            // roles
            GetRolesForToken(userName).ToList().ForEach(role => claims.Add(new Claim(System.Security.Claims.ClaimTypes.Role, role)));

            // profile claims
            claims.AddRange(GetProfileClaims(userName));

            //context claims 
            if (requestDetails.Request.AdditionalContext != null && requestDetails.Request.AdditionalContext.Items.Count() > 0)
            {
                //Aggiunta di Claim da parte del client questa logica serve per settare di lingua,company e profilo

                var passedProfile = requestDetails.Request.AdditionalContext.Items.FirstOrDefault(p => p.Name.ToString() == Sagrada.IdentityServer.ClaimTypes.Profile);
                if (passedProfile != null)
                {
                    var profiles = SagradaIdentityService.GetProfiles(userName);
                    if (profiles.Count(p => p.Item1.ToString() == passedProfile.Value) == 0)
                    {
                        string errors = string.Format("additionalContext request from {0} has a not valid claim : {1}.", requestDetails.Realm.Uri, Sagrada.IdentityServer.ClaimTypes.Profile);
                        Tracing.Error(errors);
                        throw new InvalidRequestException(errors);
                    }
                    else
                        claims.Add(new Claim(Sagrada.IdentityServer.ClaimTypes.Profile, passedProfile.Value));
                }
                
                var passedCompany = requestDetails.Request.AdditionalContext.Items.FirstOrDefault(p => p.Name.ToString() == Sagrada.IdentityServer.ClaimTypes.Company);
                if (passedCompany != null)
                {
                    var companies = SagradaIdentityService.GetCompanies();
                    if (companies.Count(p => p.Item1.ToString() == passedCompany.Value) == 0)
                    {
                        string errors = string.Format("additionalContext request from {0} has a not valid claim : {1}.", requestDetails.Realm.Uri, Sagrada.IdentityServer.ClaimTypes.Company);
                        Tracing.Error(errors);
                        throw new InvalidRequestException(errors);
                    }
                    else
                        claims.Add(new Claim(Sagrada.IdentityServer.ClaimTypes.Company, passedCompany.Value));
                }
            
                var passedLanguage = requestDetails.Request.AdditionalContext.Items.FirstOrDefault(p => p.Name.ToString() == Sagrada.IdentityServer.ClaimTypes.Language);
                if (passedLanguage != null)
                {
                    var languages = SagradaIdentityService.GetLanguages();
                    if (languages.Count(p => p.Name == passedLanguage.Value) == 0)
                    {
                        string errors = string.Format("additionalContext request from {0} has a not valid claim : {1}.", requestDetails.Realm.Uri, Sagrada.IdentityServer.ClaimTypes.Language);
                        Tracing.Error(errors);
                        throw new InvalidRequestException(errors);
                    }
                    else
                        claims.Add(new Claim(Sagrada.IdentityServer.ClaimTypes.Language, passedLanguage.Value));
                }
            
            };

            return claims;
        }

        protected virtual IEnumerable<Claim> GetProfileClaims(string userName)
        {
            return new List<Claim>();
        }

        protected virtual string GetProfileClaimType(string propertyName)
        {
            if (StandardClaimTypes.Mappings.ContainsKey(propertyName))
            {
                return StandardClaimTypes.Mappings[propertyName];
            }
            else
            {
                return string.Format("{0}{1}", ProfileClaimPrefix, propertyName);
            }
        }

        public IEnumerable<string> GetSupportedClaimTypes()
        {
            var claimTypes = new List<string>
            {
                System.Security.Claims.ClaimTypes.Name,
                System.Security.Claims.ClaimTypes.Role,
                Sagrada.IdentityServer.ClaimTypes.Profile,
                Sagrada.IdentityServer.ClaimTypes.Company,
                Sagrada.IdentityServer.ClaimTypes.Language,
            };

            return claimTypes;
        }

        protected virtual IEnumerable<string> GetRolesForToken(string userName)
        {
            var returnedRoles = new List<string>();

            if (Roles.Enabled)
            {
                var roles = Roles.GetRolesForUser(userName);
                returnedRoles = roles.Where(role => !(role.StartsWith(Thinktecture.IdentityServer.Constants.Roles.InternalRolesPrefix))).ToList();
            }

            return returnedRoles;
        }
    }
}
