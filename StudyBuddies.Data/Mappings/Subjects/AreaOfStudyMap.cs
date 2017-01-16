using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Subjects;

namespace StudyBuddies.Data.Mappings.Subjects
{
    public class AreaOfStudyMap : ClassMap<AreaOfStudy>
    {
        public AreaOfStudyMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            Map(x => x.Name)
                .Column("Name")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();
        }
    }
}
