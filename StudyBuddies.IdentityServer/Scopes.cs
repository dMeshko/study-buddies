using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Models;

namespace StudyBuddies.IdentityServer
{
    public static class Scopes
    {
        public static List<Scope> Get()
        {
            return new List<Scope>
        {
            StandardScopes.OpenId,
            StandardScopes.Profile
        };
        }
    }
}