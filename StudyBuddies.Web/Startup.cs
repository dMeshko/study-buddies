using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Web.Http;
using IdentityServer3.AccessTokenValidation;
using MB.Owin.Logging.Log4Net;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Logging;
using Owin;
using StudyBuddies.Business.Infrastructure;
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

            // Allow all origins
            app.UseCors(CorsOptions.AllowAll);

            // claims transformation, used to map received claims with their equivalents in asp.net
            JwtSecurityTokenHandler.InboundClaimTypeMap = new Dictionary<string, string>();

            // Wire token validation
            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = "https://sts.studybuddies.com",

                // For access to the introspection endpoint
                ClientId = "webapp_client",
                ClientSecret = "B451713C-4E34-4D9A-9B4B-5A40EF7F5D40",
                
                RequiredScopes = new[] { "sbapi" }
            });
            
            //ConfigureAuth(app);

            //config.Filters.Add(new AuthorizeAttribute());

            #endregion

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}