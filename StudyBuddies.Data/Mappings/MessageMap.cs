using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Mappings
{
    public class MessageMap : ClassMap<Message>
    {
        public MessageMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            References(x => x.UserFrom)
                .Cascade.All();

            References(x => x.UserTo)
                //.Column("UserTo_id")
                .Cascade.All();

            Map(x => x.Content)
                .Not.Nullable();

            Map(x => x.Date)
                .Not.Nullable();
        }
    }
}
