using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Subjects;

namespace StudyBuddies.Data.Mappings.Subjects
{
    public class SubjectMap : ClassMap<Subject>
    {
        public SubjectMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            Map(x => x.Name)
                .Column("Name")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            References(x => x.AreaOfStudy)
                .Column("AreaOfStudyId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();
        }
    }
}
