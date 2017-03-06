using FluentNHibernate.Mapping;
using StudyBuddies.Domain;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Data.Mappings.Groups
{
    public class GroupRequestMap : SubclassMap<GroupRequest>
    {
        public GroupRequestMap()
        {
            Abstract();

            References(x => x.User)
                .Column("UserId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            References(x => x.Group)
                .Column("GroupId")
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
