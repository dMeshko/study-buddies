using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Institutions;

namespace StudyBuddies.Data.Mappings.Institutions
{
    public class UniversityMap : SubclassMap<University>
    {
        public UniversityMap()
        {
            Abstract();

            Map(x => x.Name)
                .Column("Name")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Component(x => x.Location);

            HasMany(x => x.Faculties)
                .KeyColumn("UniversityId")
                .Inverse()
                .Access.CamelCaseField(Prefix.Underscore)
                .Cascade.AllDeleteOrphan();
        }
    }
}
