using FluentNHibernate.Mapping;
using StudyBuddies.Domain;
using StudyBuddies.Domain.Institutions;

namespace StudyBuddies.Data.Mappings.Institutions
{
    public class EnrolledInstitutionMap : SubclassMap<EnrolledInstitution>
    {
        public EnrolledInstitutionMap()
        {
            Abstract();

            References(x => x.User)
                .Column("UserId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            References(x => x.Institution)
                .Column("InstitutionId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Status)
                .CustomType<InstitutionStatus>()
                .Column("Status")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.GraduationDate)
                .Column("GraduationDate")
                .Access.CamelCaseField(Prefix.Underscore)
                .Nullable();
        }
    }
}
