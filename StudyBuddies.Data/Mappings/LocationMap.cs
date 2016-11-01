using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Mappings
{
    public class LocationMap : ClassMap<Location>
    {
        public LocationMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            Map(x => x.Address)
                .Not.Nullable();

            Map(x => x.City)
                .Not.Nullable();

            Map(x => x.Country)
                .Not.Nullable();
        }
    }
}
