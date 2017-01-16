using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using StudyBuddies.Data.Mappings.Users;

namespace StudyBuddies.Data.Configuration
{
    public class FluentNHibernateConfig
    {
        public static ISessionFactory CreateSessionFactory()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                    //.ConnectionString(@"Data Source=DEV-LT1;Initial Catalog=StudyBuddiesDb;User ID=wwwuser;Password=P@ssw0rd;Pooling=False")
                    .ConnectionString(@"Data Source=localhost;Initial Catalog=StudyBuddies;Integrated Security=SSPI")
                    .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                //.ExposeConfiguration(cfg => new SchemaExport(cfg).Drop(true, true))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                .BuildSessionFactory();

            return sessionFactory;
        }
    }
}
