using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Mappings
{
    public class LocationMapComponent : ComponentMap<Location>
    {
        public LocationMapComponent()
        {
            Map(x => x.Address)
                .Not.Nullable();

            Map(x => x.City)
                .Not.Nullable();

            Map(x => x.Country)
                .Not.Nullable();
        }
    }
}
