using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Data.Mappings.Users
{
    public class MessageMap : ClassMap<Message>
    {
        public MessageMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            References(x => x.UserFrom)
                .Column("UserFromId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            References(x => x.UserTo)
                .Column("UserToId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Content)
                .Column("Content")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Date)
                .Column("Date")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();
        }
    }
}
