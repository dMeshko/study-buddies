using System.Collections.Generic;
using System.Web.Http;
using MB.Owin.Logging.Log4Net;
using Microsoft.Owin;
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

            //// Allow all origins
            //app.UseCors(CorsOptions.AllowAll);

            //// Wire token validation
            //app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            //{
            //    Authority = "https://sts.studybuddies.com",
            //    RequiredScopes = new[] { "sbapi" }
            //});

            //config.Filters.Add(new AuthorizeAttribute());

            #endregion

            WebApiConfig.Register(config);
            app.UseWebApi(config);

            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}