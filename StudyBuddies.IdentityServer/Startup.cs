using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Microsoft.Owin;
using Owin;
using StudyBuddies.IdentityServer;
using StudyBuddies.IdentityServer.Factories;

[assembly: OwinStartup(typeof(Startup))]
namespace StudyBuddies.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var factory = new IdentityServerServiceFactory()
                .UseInMemoryClients(Clients.Get())
                .UseInMemoryScopes(Scopes.Get())
                .UseInMemoryUsers(Users.Get()); // todo: remove this when userService is done

            //todo
            //var userService = new UserService();
            //factory.UserService = new Registration<IUserService>(resolve => _userService);        

            app.UseIdentityServer(new IdentityServerOptions
            {
                SiteName = "StudyBuddies IdentityServer",
                SigningCertificate = LoadCertificate(),
                RequireSsl = true,
                Factory = factory
            });
        }

        private static X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"bin\Certificates\studybuddies.pfx"), "administrator");
        }
    }
}