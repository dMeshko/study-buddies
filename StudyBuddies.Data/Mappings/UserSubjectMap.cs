using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Mappings
{
    public class UserSubjectMap : ClassMap<UserSubject>
    {
        public UserSubjectMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            References(x => x.User)
                .Cascade.All();

            References(x => x.Subject)
                .Cascade.All();

            Map(x => x.Grade)
                .Not.Nullable();

            Map(x => x.Passed)
                .Not.Nullable();
        }
    }
}
