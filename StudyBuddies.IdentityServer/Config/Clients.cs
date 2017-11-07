using System.Collections.Generic;
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
                    },

                    //client secret
                    //ClientSecrets = new List<Secret>
                    //{
                    //    new Secret(Constants.StudyBuddiesSecret.Sha256())
                    //}
                }
            };
        }
    }
}