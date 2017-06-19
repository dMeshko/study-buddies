using System;
using System.Collections.Generic;
using System.Web;
using IdentityServer3.Core.Models;

namespace StudyBuddies.IdentityServer
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
                ClientName = "WebApp Client",
                ClientId = "webapp_client",
                Flow = Flows.Implicit,
                ClientSecrets = new List<Secret>
                {
                    new Secret("B451713C-4E34-4D9A-9B4B-5A40EF7F5D40".Sha256())
                },
                RedirectUris = new List<string> // though which routers can is3 ret. tokens or codes
                {
                    "https://web.studybuddies.com/#/login"
                },
                PostLogoutRedirectUris = new List<string>
                {
                    "https://web.studybuddies.com/"
                },
                AllowedCorsOrigins = new List<string>
                {
                    "https://web.studybuddies.com"
                },
                AccessTokenType = AccessTokenType.Jwt,
                AccessTokenLifetime = 360,
                IdentityTokenLifetime = 360,
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