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
                StandardScopes.ProfileAlwaysInclude,
                new Scope
                {
                    Enabled = true,
                    DisplayName = "Role(s)",
                    Name = "roles",
                    Description = "Allow the application to see your role(s).", 
                    Type = ScopeType.Identity,
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim("role", true)
                    }
                },
                new Scope
                {
                    Enabled = true,
                    DisplayName = "StudyBuddies Web API",
                    Description = "Access to the StudyBuddies API",
                    Name = "sbapi",
                    Type = ScopeType.Resource,
                    Claims = new List<ScopeClaim>
                    {
                        new ScopeClaim("role", false)
                    }
                }
            };

            scopes.AddRange(StandardScopes.All);
            return scopes;
        }
    }
}