using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Web.Http;
using IdentityServer3.AccessTokenValidation;
using Owin;
using StudyBuddies.Business.Infrastructure;
using StudyBuddies.Core;

namespace StudyBuddies.Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            AutofacConfig.Configure(app, config);
            AutoMapperConfig.Configure();
            FluentValidatoinConfig.Configure(config);

            #region Identity Server

            // override the config to ignore microsoft claim types remapping and use identity server rules instead
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap = new Dictionary<string, string>();

            app.UseIdentityServerBearerTokenAuthentication(new IdentityServerBearerTokenAuthenticationOptions
            {
                Authority = Constants.StudyBuddiesStsUrl,
                RequiredScopes = new[]
                {
                    "sbapi"
                }
            });
            config.Filters.Add(new AuthorizeAttribute());

            #endregion

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}