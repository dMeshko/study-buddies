using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Mappings
{
    public class UserAttendsInstitutionMap : ClassMap<UserAttendsInstitution>
    {
        public UserAttendsInstitutionMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            References(x => x.User)
                .Cascade.All();

            References(x => x.Institution)
                .Cascade.All();

            Map(x => x.StartDate)
                .Not.Nullable();

            Map(x => x.EndDate)
                .Nullable();
        }
    }
}
