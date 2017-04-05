using System;
using System.Collections.Generic;
using System.Linq;
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
                ClientName = "JS Client",
                ClientId = "js",
                Flow = Flows.Implicit,

                RedirectUris = new List<string>
                {
                    "http://localhost:56668/popup.html"
                },

                AllowedCorsOrigins = new List<string>
                {
                    "http://localhost:56668"
                },

                AllowAccessToAllScopes = true
            }
        };
        }
    }
}