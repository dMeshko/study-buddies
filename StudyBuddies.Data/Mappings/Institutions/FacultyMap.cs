using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Institutions;

namespace StudyBuddies.Data.Mappings.Institutions
{
    public class FacultyMap : SubclassMap<Faculty>
    {
        public FacultyMap()
        {
            References(x => x.University)
                .Column("UniversityId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();
        }
    }
}
