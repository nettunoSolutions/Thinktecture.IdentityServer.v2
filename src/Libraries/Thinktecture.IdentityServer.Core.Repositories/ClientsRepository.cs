﻿/*
 * Copyright (c) Dominick Baier.  All rights reserved.
 * see license.txt
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Thinktecture.IdentityServer.Models;

namespace Thinktecture.IdentityServer.Repositories.Sql
{
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ClientsRepository : IClientsRepository
    {
        //#region Runtime
        //public bool TryGetUserNameFromThumbprint(X509Certificate2 certificate, out string userName)
        //{
        //    userName = null;

        //    using (var entities = IdentityServerConfigurationContext.Get())
        //    {
        //        userName = (from mapping in entities.ClientCertificates
        //                    where mapping.Thumbprint.Equals(certificate.Thumbprint, StringComparison.OrdinalIgnoreCase)
        //                    select mapping.UserName).FirstOrDefault();

        //        return (userName != null);
        //    }
        //}
        //#endregion

        //#region Management
        //public bool SupportsWriteAccess
        //{
        //    get { return true; }
        //}

        //public IEnumerable<string> List(int pageIndex, int pageSize)
        //{
        //    using (var entities = IdentityServerConfigurationContext.Get())
        //    {
        //        var users =
        //            (from user in entities.ClientCertificates
        //             orderby user.UserName
        //             select user.UserName)
        //            .Distinct();

        //        if (pageIndex != -1 && pageSize != -1)
        //        {
        //            users = users.Skip(pageIndex * pageSize).Take(pageSize);
        //        }

        //        return users.ToList();
        //    }
        //}

        //public IEnumerable<ClientCertificate> GetClientCertificatesForUser(string userName)
        //{
        //    using (var entities = IdentityServerConfigurationContext.Get())
        //    {
        //        var certs =
        //             from record in entities.ClientCertificates
        //             where record.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)
        //             select record;

        //        return certs.ToList().ToDomainModel();
        //    }
        //}

        //public void Add(ClientCertificate certificate)
        //{
        //    using (var entities = IdentityServerConfigurationContext.Get())
        //    {
        //        var record =
        //            (from entry in entities.ClientCertificates
        //             where entry.UserName.Equals(certificate.UserName, StringComparison.OrdinalIgnoreCase) &&
        //                   entry.Thumbprint.Equals(certificate.Thumbprint, StringComparison.OrdinalIgnoreCase)
        //             select entry)
        //            .SingleOrDefault();
        //        if (record == null)
        //        {
        //            record = new ClientCertificates
        //            {
        //                UserName = certificate.UserName,
        //                Thumbprint = certificate.Thumbprint,
        //            };
        //            entities.ClientCertificates.Add(record);
        //        }
        //        record.Description = certificate.Description;
        //        entities.SaveChanges();
        //    }
        //}

        //public void Delete(ClientCertificate certificate)
        //{
        //    using (var entities = IdentityServerConfigurationContext.Get())
        //    {
        //        var record =
        //            (from entry in entities.ClientCertificates
        //             where entry.UserName.Equals(certificate.UserName, StringComparison.OrdinalIgnoreCase) &&
        //                   entry.Thumbprint.Equals(certificate.Thumbprint, StringComparison.OrdinalIgnoreCase)
        //             select entry)
        //            .SingleOrDefault();
        //        if (record != null)
        //        {
        //            entities.ClientCertificates.Remove(record);
        //            entities.SaveChanges();
        //        }
        //    }
        //}
        //#endregion

        public bool ValidateClient(string clientId, string clientSecret)
        {
            using (var entities = IdentityServerConfigurationContext.Get())
            {
                var client = (from c in entities.Clients
                              where c.ClientId.Equals(clientId, StringComparison.Ordinal) &&
                                    c.ClientSecret.Equals(clientSecret, StringComparison.Ordinal)
                              select c).SingleOrDefault();

                return (client != null);
            }
            
        }

        public bool TryGetClient(string clientId, out Models.Client client)
        {
            using (var entities = IdentityServerConfigurationContext.Get())
            {
                var record = (from c in entities.Clients
                              where c.ClientId.Equals(clientId, StringComparison.Ordinal)
                              select c).SingleOrDefault();

                if (record != null)
                {
                    client = record.ToDomainModel();
                    return true;
                }

                client = null;
                return false;
            }
        }
        
        public IEnumerable<Models.Client> GetAll()
        {
            using (var entities = IdentityServerConfigurationContext.Get())
            {
                return entities.Clients.ToArray().Select(x => x.ToDomainModel()).ToArray();
            }
        }


        public void Delete(int id)
        {
            using (var entities = IdentityServerConfigurationContext.Get())
            {
                var item = entities.Clients.Where(x => x.Id == id).SingleOrDefault();
                if (item != null)
                {
                    entities.Clients.Remove(item);
                    entities.SaveChanges();
                }
            }
        }
        public void Update(Models.Client model)
        {
            if (model == null) throw new ArgumentException("model");

            using (var entities = IdentityServerConfigurationContext.Get())
            {
                var item = entities.Clients.Where(x => x.Id == model.ID).Single();
                model.UpdateEntity(item);
                entities.SaveChanges();
            }
        }

        public void Create(Models.Client model)
        {
            if (model == null) throw new ArgumentException("model");

            using (var entities = IdentityServerConfigurationContext.Get())
            {
                var item = new Client();
                model.UpdateEntity(item);
                entities.Clients.Add(item);
                entities.SaveChanges();
                model.ID = item.Id;
            }
        }


        public Models.Client Get(int id)
        {
            using (var entities = IdentityServerConfigurationContext.Get())
            {
                var item = entities.Clients.Where(x => x.Id == id).SingleOrDefault();
                if (item != null)
                {
                    return item.ToDomainModel();
                }
                return null;
            }
        }
    }
}