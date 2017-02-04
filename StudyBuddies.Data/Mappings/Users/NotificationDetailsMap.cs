using FluentNHibernate.Mapping;
using StudyBuddies.Domain;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Data.Mappings.Users
{
    public class NotificationDetailsMap : ClassMap<NotificationDetails>
    {
        public NotificationDetailsMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            Map(x => x.NotificationType)
                .Column("NotificationType")
                .CustomType<NotificationType>()
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.NotificationMeta)
                .Column("Meta")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();
        }
    }
}
