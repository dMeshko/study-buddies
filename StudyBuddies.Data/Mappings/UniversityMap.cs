using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Mappings
{
    public class UniversityMap : ClassMap<University>
    {
        public UniversityMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            Map(x => x.Name)
                .Unique()
                .Not.Nullable();

            /*HasOne(x => x.Location)
                .Cascade.All();*/

            Component(x => x.Location);

            HasMany(x => x.Faculties)
                .Inverse()
                .Cascade.All();
        }
    }
}
