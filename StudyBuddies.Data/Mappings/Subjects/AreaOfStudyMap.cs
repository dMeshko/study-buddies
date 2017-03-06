using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Subjects;

namespace StudyBuddies.Data.Mappings.Subjects
{
    public class AreaOfStudyMap : SubclassMap<AreaOfStudy>
    {
        public AreaOfStudyMap()
        {
            Abstract();

            Map(x => x.Name)
                .Column("Name")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();
        }
    }
}
