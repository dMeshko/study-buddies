using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Institutions;

namespace StudyBuddies.Data.Mappings.Institutions
{
    public class LocationMap : SubclassMap<Location>
    {
        public LocationMap()
        {
            Abstract();

            Map(x => x.Address)
                .Column("Address")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.City)
                .Column("City")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Country)
                .Column("Country")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();
        }
    }
}
