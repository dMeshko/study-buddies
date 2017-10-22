using System;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using NHibernate;
using Owin;
using StudyBuddies.Business.Services;
using StudyBuddies.Data.Configuration;
using StudyBuddies.Data.Infrastructure;

namespace StudyBuddies.Host
{
    public class AutofacConfig
    {
        public static void Configure(IAppBuilder app, HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);


            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest().PropertiesAutowired();
            builder.RegisterInstance(FluentNHibernateConfig.CreateSessionFactory()).As<ISessionFactory>();

            //builder.RegisterModule();
            // Register dependencies, then...
            // scans for services in the services assembly
            builder.RegisterAssemblyTypes(typeof(IUserService).Assembly)
                .Where(x => x.Namespace.EndsWith(".Implementation"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            // scans for repositories in the repositories assembly
            builder.RegisterAssemblyTypes(typeof(IRepository<Object>).Assembly)
                .Where(x => x.Namespace.EndsWith(".Implementation"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseWebApi(config);
        }
    }
}