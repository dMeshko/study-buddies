using FluentNHibernate.Mapping;
using StudyBuddies.Domain;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Data.Mappings.Groups
{
    public class GroupRequestMap : ClassMap<GroupRequest>
    {
        public GroupRequestMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

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
