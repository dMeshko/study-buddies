using FluentNHibernate.Mapping;
using StudyBuddies.Domain;
using StudyBuddies.Domain.Subjects;

namespace StudyBuddies.Data.Mappings.Subjects
{
    public class EnrolledSubjectMap : ClassMap<EnrolledSubject>
    {
        public EnrolledSubjectMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            References(x => x.User)
                .Column("UserId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            References(x => x.Subject)
                .Column("SubjectId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Status)
                .CustomType<SubjectStatus>()
                .Column("Status")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Grade)
                .Column("Grade")
                .Access.CamelCaseField(Prefix.Underscore)
                .Nullable();
        }
    }
}
