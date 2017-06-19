using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Data.Mappings.Users
{
    public class RoleMap : SubclassMap<Role>
    {
        public RoleMap()
        {
            Abstract();

            Map(x => x.Name)
                .Access.CamelCaseField(Prefix.Underscore)
                .Column("Name")
                .Length(25)
                .Not.Nullable();

            HasManyToMany(x => x.Users)
                .Access.CamelCaseField(Prefix.Underscore)
                .Cascade.All()
                .Inverse();
        }
    }
}
