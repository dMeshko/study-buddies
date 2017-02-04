using FluentNHibernate.Mapping;
using StudyBuddies.Domain;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Data.Mappings.Users
{
    public class NotificationMap : ClassMap<Notification>
    {
        public NotificationMap()
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

            //References(x => x.SourceEntity)
            //    .Column("SourceEntityId")
            //    .Access.CamelCaseField(Prefix.Underscore)
            //    .Not.Nullable();

            Map(x => x.Date)
                .Column("Date")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.NotificationType)
                .CustomType<NotificationType>()
                .Column("NotificationType")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Seen)
                .Access.CamelCaseField(Prefix.Underscore)
                .Column("Seen")
                .Not.Nullable();
        }
    }
}
