using System;
using System.Collections.Generic;
using System.Web;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;

namespace StudyBuddies.IdentityServer.Config
{
    public static class Scopes
    {
        public static List<Scope> Get()
        {
            var scopes = new List<Scope>
            {
                StandardScopes.OpenId,
                StandardScopes.Profile,
                new Scope
                {
                    Enabled = true,
                    DisplayName = "Roles",
                    Name = "roles",
                    Type = ScopeType.Identity,
                    Claims = new List<ScopeClaim>()
                    {
                        new ScopeClaim("role")
                    }
                },
                new Scope
                {
                    Enabled = true,
                    DisplayName = "StudyBuddies Web API",
                    Name = "sbapi",
                    Description = "Access to the StudyBuddies API",
                    Type = ScopeType.Resource,
                    ScopeSecrets = new List<Secret>
                    {
                        new Secret("B451713C-4E34-4D9A-9B4B-5A40EF7F5D40".Sha256())
                    },
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim(Constants.ClaimTypes.GivenName),
                        new ScopeClaim(Constants.ClaimTypes.Email)
                    }
                }
            };

            scopes.AddRange(StandardScopes.All);
            return scopes;
        }
    }
}