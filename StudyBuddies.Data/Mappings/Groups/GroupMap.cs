using FluentNHibernate.Mapping;
using StudyBuddies.Domain;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Data.Mappings.Groups
{
    public class GroupMap : SubclassMap<Group>
    {
        public GroupMap()
        {
            Abstract();

            Map(x => x.Name)
                .Column("Name")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Description)
                .Column("Description")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.GroupCapacity)
                .Column("Capacity")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            References(x => x.Admin)
                .Column("AdminId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            References(x => x.Subject)
                .Column("SubjectId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            HasMany(x => x.Members)
                .Access.CamelCaseField(Prefix.Underscore)
                .Inverse()
                .Cascade.AllDeleteOrphan();

            HasMany(x => x.Ratings)
                .Access.CamelCaseField(Prefix.Underscore)
                .Inverse()
                .Cascade.AllDeleteOrphan();

            Map(x => x.Status)
                .CustomType<GroupStatus>()
                .Column("Status")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            HasMany(x => x.Posts)
                .Access.CamelCaseField(Prefix.Underscore)
                .Inverse()
                .Cascade.AllDeleteOrphan()
                .OrderBy("Date DESC");
        }
    }
}
