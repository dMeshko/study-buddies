using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Mappings
{
    public class AcademyMap : SubclassMap<Academy>
    {
        public AcademyMap()
        {
            HasMany(x => x.Locations)
                .Cascade.All();
        }
    }
}
