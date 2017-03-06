using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Data.Mappings.Groups
{
    public class CommentMap : SubclassMap<Comment>
    {
        public CommentMap()
        {
            Abstract();

            References(x => x.User)
                .Column("UserId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            References(x => x.Post)
                .Column("PostId")
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
        }
    }
}
