using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using IdentityServer3.AccessTokenValidation;
using MB.Owin.Logging.Log4Net;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Logging;
using NHibernate;
using Owin;
using StudyBuddies.Business.Infrastructure;
using StudyBuddies.Business.Services;
using StudyBuddies.Data.Configuration;
using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain;
using StudyBuddies.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace StudyBuddies.Web
{
    public class Startup
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

            //todo
            // Allow all origins
            app.UseCors(CorsOptions.AllowAll);

            // Wire token validation
            //appBuilder.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            //{
            //    Authority = "https://localhost:44326",

            //    // For access to the introspection endpoint
            //    ClientId = "api",
            //    ClientSecret = "api-secret",

            //    RequiredScopes = new[] { "api" }
            //});

            //config.Filters.Add(new AuthorizeAttribute());

            #endregion

            WebApiConfig.Register(config);
        }
    }
}