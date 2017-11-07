using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using StudyBuddies.Core;

namespace StudyBuddies.Web
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // in api the cookie is used to STORE the access token, while here
            // we're using cookies as a means of authentication for the client
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            // openId authentication handler methods
            var notificationHandlers = new OpenIdConnectAuthenticationNotifications
            {
                SecurityTokenValidated = async x =>
                {
                    // do sht here
                    var y = x.ProtocolMessage.AccessToken;
                }
            };

            //https://github.com/IdentityServer/IdentityServer3.Samples/tree/master/source/Clients/MVC%20OWIN%20Client
            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "sb_hybrid",
                Authority = Constants.StudyBuddiesStsUrl,
                RedirectUri = Constants.StudyBuddiesWebUrl,
                SignInAsAuthenticationType = "Cookies",
                ResponseType = "code id_token token",
                Scope = "openid profile sbapi",
                Notifications = notificationHandlers
            });
        }
    }
}