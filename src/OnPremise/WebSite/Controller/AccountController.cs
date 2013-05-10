/*
 * Copyright (c) Dominick Baier, Brock Allen.  All rights reserved.
 * see license.txt
 */

using Sagrada.IdentityServer.Module;
using System.ComponentModel.Composition;
using System.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using Thinktecture.IdentityServer.Protocols;
using Thinktecture.IdentityServer.Repositories;
using Thinktecture.IdentityServer.Web.ViewModels;
using System.Collections.Generic;

namespace Thinktecture.IdentityServer.Web.Controllers
{
    public class AccountController : AccountControllerBase
    {
        [Import]
        public ISagradaIdentityService SagradaIdentityService { get; set; }

        public AccountController()
            : base()
        { }

        public AccountController(IUserRepository userRepository, IConfigurationRepository configurationRepository)
            : base(userRepository, configurationRepository)
        {

        }

        // shows the signin screen
        public ActionResult SignIn(string returnUrl, bool mobile = false)
        {
            // you can call AuthenticationHelper.GetRelyingPartyDetailsFromReturnUrl to get more information about the requested relying party

            var vm = new SignInModel()
            {
                ReturnUrl = returnUrl,
                ShowClientCertificateLink = ConfigurationRepository.Global.EnableClientCertificateAuthentication,
                IsPreAutenticated = false
            };

            if (mobile)
                vm.IsSigninRequest = true;

            SetLanguage(vm);

            return View(vm);
        }

        private void SetLanguage(SignInModel model)
        {
            model.Languages = from c in SagradaIdentityService.GetLanguages()
                              select new SelectListItem()
                              {
                                  Value = c.Name,
                                  Text = c.DisplayName
                              };
        }

        private void SetCompanies(SignInModel model)
        {
            model.Companies = from c in SagradaIdentityService.GetCompanies()
                              select new SelectListItem()
                              {
                                  Value = c.Item1.ToString(),
                                  Text = c.Item2
                              };
        }

        // handles the signin
        [HttpPost]
        public ActionResult SignIn(SignInModel model)
        {
            SetCompanies(model);
            SetLanguage(model);
            model.ShowClientCertificateLink = ConfigurationRepository.Global.EnableClientCertificateAuthentication;

            if (model.IsPreAutenticated || ModelState.IsValid)
            {
                if (model.IsPreAutenticated)
                {
                    //step 2
                    return SignIn(
                        model.UserName,
                        AuthenticationMethods.Password,
                        model.ReturnUrl,
                        model.EnableSSO,
                        ConfigurationRepository.Global.SsoCookieLifetime
                        , new[]
                        {
                            new Claim(Sagrada.IdentityServer.ClaimTypes.Language,model.Language.Value),
                            new Claim(Sagrada.IdentityServer.ClaimTypes.Company,model.Company.Value),
                            new Claim(Sagrada.IdentityServer.ClaimTypes.Profile,model.Profile.Value)
                        });
                }
                else
                {
                    //step 1 selezione profilo e company
                    if (UserRepository.ValidateUser(model.UserName, model.Password))
                    {

                        model.Profiles = from c in SagradaIdentityService.GetProfiles(model.UserName)
                                         select new SelectListItem()
                                         {
                                             Value = c.Item1.ToString(),
                                             Text = c.Item2
                                         };
                        if (model.Profiles.Count() == 0)
                        {
                            ModelState.AddModelError("", Resources.AccountController.IncorrectCredentialsNoProfile);
                            return View(model);
                        }

                        model.IsPreAutenticated = true;
                        SetCompanies(model);
                        SetLanguage(model);

                        if (model.Profiles.Count() == 1 && model.Companies.Count() == 1)
                        {
                            //step 2
                            return SignIn(
                                model.UserName,
                                AuthenticationMethods.Password,
                                model.ReturnUrl,
                                model.EnableSSO,
                                ConfigurationRepository.Global.SsoCookieLifetime
                                , new[]
                                    {
                                        new Claim(Sagrada.IdentityServer.ClaimTypes.Language,model.Language.Value),
                                        new Claim(Sagrada.IdentityServer.ClaimTypes.Company,model.Companies.First().Value),
                                        new Claim(Sagrada.IdentityServer.ClaimTypes.Profile,model.Profiles.First().Value)
                                    });
                        }

                        return View(model);
                    }


                    //return SignIn(
                    //    model.UserName,
                    //    AuthenticationMethods.Password,
                    //    model.ReturnUrl,
                    //    model.EnableSSO,
                    //    ConfigurationRepository.Global.SsoCookieLifetime);



                    //new[] { c ,c1});
                }
            }

            ModelState.AddModelError("", Resources.AccountController.IncorrectCredentialsNoAuthorization);
            return View(model);
        }

        // handles client certificate based signin
        public ActionResult CertificateSignIn(string returnUrl)
        {
            if (!ConfigurationRepository.Global.EnableClientCertificateAuthentication)
            {
                return new HttpNotFoundResult();
            }

            var clientCert = HttpContext.Request.ClientCertificate;

            if (clientCert != null && clientCert.IsPresent && clientCert.IsValid)
            {
                string userName;
                if (UserRepository.ValidateUser(new X509Certificate2(clientCert.Certificate), out userName))
                {
                    // establishes a principal, set the session cookie and redirects
                    // you can also pass additional claims to signin, which will be embedded in the session token

                    return SignIn(
                        userName,
                        AuthenticationMethods.X509,
                        returnUrl,
                        false,
                        ConfigurationRepository.Global.SsoCookieLifetime);
                }
            }

            return View("Error");
        }
    }
}
