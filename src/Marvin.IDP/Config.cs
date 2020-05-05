using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Marvin.IDP
{
    public static class Config
    {
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = new Guid().ToString(), // SubjectId must be unique for each user
                    Username = "jordan",
                    Password = "password",
                    Claims = new List<Claim> // Claims represent information about user
                    {
                        new Claim("given_name", "Jordan"),
                        new Claim("family_name","Lee")
                    }
                },
                new TestUser
                {
                    SubjectId = new Guid().ToString(),
                    Username = "max",
                    Password = "password",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Max"),
                        new Claim("family_name","Payne")
                    }
                }
            };
        }

        /// <summary>
        /// Identity resources map to scopes which give Identity related information
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
                {
                    new IdentityResources.OpenId(), // Subject claim is returned
                    new IdentityResources.Profile() // Profile related claims (e.g. given_name, family_name)
                };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>();
        }
    }
}
