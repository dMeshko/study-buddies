using FluentNHibernate.Mapping;
using StudyBuddies.Domain;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Data.Mappings.Users
{
    public class BuddyRequestMap : SubclassMap<BuddyRequest>
    {
        public BuddyRequestMap()
        {
            Abstract();

            References(x => x.UserFrom)
                .Column("UserFromId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            References(x => x.UserTo)
                .Column("UserToId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Date)
                .Column("Date")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Status)
                .CustomType<RequestStatus>()
                .Column("Status")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();
        }
    }
}
