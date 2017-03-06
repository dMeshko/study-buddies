using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Data.Mappings.Groups
{
    public class GroupRatingMap : SubclassMap<GroupRating>
    {
        public GroupRatingMap()
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

            References(x => x.Group)
                .Column("GroupId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Date)
                .Column("Date")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Grade)
                .Column("Grade")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();
        }
    }
}
