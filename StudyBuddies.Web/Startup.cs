using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(StudyBuddies.Web.Startup))]
namespace StudyBuddies.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}