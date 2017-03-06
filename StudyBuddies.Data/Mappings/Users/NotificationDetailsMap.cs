using FluentNHibernate.Mapping;
using StudyBuddies.Domain;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Data.Mappings.Users
{
    public class NotificationDetailsMap : SubclassMap<NotificationDetails>
    {
        public NotificationDetailsMap()
        {
            Abstract();

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
