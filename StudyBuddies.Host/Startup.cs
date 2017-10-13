using System.Web.Http;
using Owin;

namespace StudyBuddies.Host
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            AutofacConfig.Configure(app, config);

            #region Identity Server

            

            #endregion

            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}