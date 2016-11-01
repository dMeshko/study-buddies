using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Mappings
{
    class GroupRatingMap : ClassMap<GroupRating>
    {
        public GroupRatingMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            References(x => x.UserFrom)
                .Cascade.All();

            References(x => x.UserTo)
                .Cascade.All();

            References(x => x.Group)
                .Cascade.All();

            Map(x => x.Date)
                .Not.Nullable();

            Map(x => x.Grade)
                .Not.Nullable();
        }
    }
}
