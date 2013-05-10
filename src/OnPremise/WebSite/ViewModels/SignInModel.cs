/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Thinktecture.IdentityServer.Web.ViewModels
{
    public class SignInModel
    {
        [Required]
        [Display(Name = "UserName", ResourceType = typeof(Resources.SignInModel))]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resources.SignInModel))]
        public string Password { get; set; }

        [Display(Name = "EnableSSO", ResourceType = typeof(Resources.SignInModel))]
        public bool EnableSSO { get; set; }

        bool? isSigninRequest;
        public bool IsSigninRequest
        {
            get
            {
                if (isSigninRequest == null)
                {
                    isSigninRequest = !String.IsNullOrWhiteSpace(ReturnUrl);
                }
                return isSigninRequest.Value;
            }
            set
            {
                isSigninRequest = value;
            }
        }
        public string ReturnUrl { get; set; }
        public bool ShowClientCertificateLink { get; set; }

        [Display(Name = "Profile", ResourceType = typeof(Resources.SignInModel))]
        public SelectListItem Profile { get; set; }
        [Display(Name = "Company", ResourceType = typeof(Resources.SignInModel))]
        public SelectListItem Company { get; set; }
        [Display(Name = "Language", ResourceType = typeof(Resources.SignInModel))]
        public SelectListItem Language { get; set; }

        /// <summary>
        /// Lingue disponibili
        /// </summary>
        public IEnumerable<SelectListItem> Languages { get; set; }
        /// <summary>
        /// Società disponibili
        /// </summary>
        public IEnumerable<SelectListItem> Companies { get; set; }
        /// <summary>
        /// Profili disponibili
        /// </summary>
        public IEnumerable<SelectListItem> Profiles { get; set; }
        /// <summary>
        /// Flag per la visulizzazione dei campi profili e company
        /// </summary>
        public bool IsPreAutenticated { get; set; }
    }
}