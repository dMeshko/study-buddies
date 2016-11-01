using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Mappings
{
    public class InstitutionMap : ClassMap<Institution>
    {
        public InstitutionMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            Map(x => x.Name)
                .Unique()
                .Not.Nullable();

            HasMany(x => x.AreasOfStudy)
                .Cascade.All();

            HasManyToMany(x => x.Subjects)
                .Cascade.All();

            HasMany(x => x.UsersAttending)
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}
