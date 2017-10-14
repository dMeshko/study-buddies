using System;
using System.Collections.Generic;
using System.Web;
using IdentityServer3.Core.Models;
using StudyBuddies.Core;

namespace StudyBuddies.IdentityServer.Config
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
                new Client
                {
                    Enabled = true,
                    ClientName = "StudyBuddies Hybrid Client",
                    ClientId = "sb_hybrid",
                    Flow = Flows.Hybrid,
                    AllowAccessToAllScopes = true,

                    // redirect uri of the app
                    RedirectUris = new List<string>
                    {
                        Constants.StudyBuddiesWebUrl
                    }
                },

                new Client
                {
                    Enabled = true,
                    ClientName = "StudyBuddies Authorization Code Client",
                    ClientId = "sb_authcode",
                    Flow = Flows.AuthorizationCode,

                    // uri of the MVC app callback
                    RedirectUris = new List<string>
                    {
                        ""
                    },

                    //client secret
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("B451713C-4E34-4D9A-9B4B-5A40EF7F5D40".Sha256())
                    }
                }, 

            new Client
            {
                Enabled = true,
                ClientName = "StudyBuddies Implicit Client",
                ClientId = "sb_implicit",
                Flow = Flows.Implicit,
                // the token will be returned to this page..
                RedirectUris = new List<string>
                {
                    "https://web.studybuddies.com/callback"
                },
                PostLogoutRedirectUris = new List<string>
                {
                    "https://web.studybuddies.com/"
                },
                AllowedCorsOrigins = new List<string>
                {
                    "https://web.studybuddies.com"
                },
                AllowAccessToAllScopes = true
            },
            //new Client
            //{
            //    Enabled = true,
            //    ClientName = "WebApp Client",
            //    ClientId = "webapp_client",
            //    Flow = Flows.ClientCredentials,
            //    AccessTokenType = AccessTokenType.Jwt,
            //    AccessTokenLifetime = 3600,
            //    ClientSecrets = new List<Secret>
            //    {
            //        new Secret("B451713C-4E34-4D9A-9B4B-5A40EF7F5D40".Sha256())
            //    },
            //    AllowedScopes = new List<string>
            //    {
            //        "sbapi"
            //    }
            //}
        };
        }
    }
}