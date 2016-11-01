using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Mappings
{
    public class FriendshipMap : ClassMap<Friendship>
    {
        public FriendshipMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            References(x => x.UserFrom)
                .Cascade.All();

            References(x => x.UserTo)
                .Cascade.All();

            Map(x => x.Date)
                .Not.Nullable();

            Map(x => x.Status)
                .Not.Nullable();
        }
    }
}
