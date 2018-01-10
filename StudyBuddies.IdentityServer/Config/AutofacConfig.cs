using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using NHibernate;
using Owin;
using StudyBuddies.Data.Configuration;
using StudyBuddies.Data.Infrastructure;

namespace StudyBuddies.IdentityServer.Config
{
    public class AutofacConfig
    {
        public static void Configure(IAppBuilder app, HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest().PropertiesAutowired();
            builder.RegisterInstance(FluentNHibernateConfig.CreateSessionFactory()).As<ISessionFactory>();

            // scans for repositories in the repositories assembly
            builder.RegisterAssemblyTypes(typeof(IRepository<Object>).Assembly)
                .Where(x => x.Namespace.EndsWith(".Implementation"))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            //app.UseAutofacMiddleware(container);
        }
    }
}