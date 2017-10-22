using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using StudyBuddies.Data.Infrastructure;
using NHibernate;
using Owin;
using StudyBuddies.Business.Services;
using StudyBuddies.Data.Configuration;
using StudyBuddies.Domain;
using StudyBuddies.Web.Providers;

namespace StudyBuddies.Web
{
    public class AutofacConfig
    {
        public static void Configure(HttpConfiguration globalConfiguration, IAppBuilder app)
        {
            // autofac
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest().PropertiesAutowired();

            builder.RegisterInstance(FluentNHibernateConfig.CreateSessionFactory()).As<ISessionFactory>();

            // scan for IUserApplicationService?
            // http://docs.autofac.org/en/latest/faq/injecting-configured-parameters.html?highlight=lambda%20expression
            //builder.RegisterType<SiteContextProvider>()
            //    .As<ISiteContextProvider>()
            //    .InstancePerRequest();

            //builder.Register(x =>
            //{
            //    var isMobileDevice = x.Resolve<ISiteContextProvider>().IsMobile;
            //    if (isMobileDevice)
            //        return x.Resolve<IUserService>();

            //    return x.Resolve<IUserService>();
            //})
            //.AsImplementedInterfaces()
            //.InstancePerRequest();

            // scans for services in the services assembly
            builder.RegisterAssemblyTypes(typeof(IUserService).Assembly)
                .Where(x => x.Namespace.EndsWith(".Implementation"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // scans for repositories in the repositories assembly
            builder.RegisterAssemblyTypes(typeof(IRepository<BaseEntity>).Assembly)
                .Where(x => x.Namespace.EndsWith(".Implementation"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
            
            var container = builder.Build();
            globalConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(globalConfiguration);
        }
    }
}