using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Web.Http;
using MB.Owin.Logging.Log4Net;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using Owin;
using StudyBuddies.Business.Infrastructure;
using StudyBuddies.Core;
using StudyBuddies.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace StudyBuddies.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            AutofacConfig.Configure(config, app);
            AutoMapperConfig.Configure();
            FluentValidatoinConfig.Configure(config);

            app.UseLog4Net();
            app.CreateLogger<Startup>();

            #region Identity Server

            //// Allow all origins
            //app.UseCors(CorsOptions.AllowAll);

            //// Wire token validation
            //app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            //{
            //    Authority = "https://sts.studybuddies.com",
            //    RequiredScopes = new[] { "sbapi" }
            //});

            //config.Filters.Add(new AuthorizeAttribute());

            // override the config to ignore microsoft claim types remapping and use identity server rules instead
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "Cookies"
            });

            app.UseOpenIdConnectAuthentication(new OpenIdConnectAuthenticationOptions
            {
                ClientId = "sb_hybrid",
                Authority = Constants.StudyBuddiesStsUrl,
                RedirectUri = Constants.StudyBuddiesWebUrl,
                SignInAsAuthenticationType = "Cookies",
                ResponseType = "id_token code token",
                Scope = "openid profile sbapi roles",
                //notifications?
            });

            #endregion

            WebApiConfig.Register(config);
            app.UseWebApi(config);

            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}