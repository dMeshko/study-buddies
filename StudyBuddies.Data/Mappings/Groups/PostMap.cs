using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Data.Mappings.Groups
{
    public class PostMap : SubclassMap<Post>
    {
        public PostMap()
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

            Map(x => x.Date)
                .Column("Date")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Content)
                .Column("Content")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            HasMany(x => x.Attachments)
                .Access.CamelCaseField(Prefix.Underscore)
                .KeyColumn("PostId")
                .Inverse()
                .Cascade.AllDeleteOrphan();

            HasMany(x => x.Comments)
                .Access.CamelCaseField(Prefix.Underscore)
                .KeyColumn("PostId")
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}
