using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Mappings
{
    public class GroupMap : ClassMap<Group>
    {
        public GroupMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            Map(x => x.Name)
                .Length(30)
                .Not.Nullable();

            Map(x => x.MaxNumberOfMembers)
                .Not.Nullable();

            Map(x => x.CreatedOn) //add some date restriction?
                .Not.Nullable();

            Map(x => x.ExpireDate) //make it so it's not before today
                .Not.Nullable();

            References(x => x.Creator);

            HasMany(x => x.Members)
                .Inverse()
                .Cascade.All()
                .Table("UserGroups");

            References(x => x.Subject)
                .Not.Nullable();

            HasMany(x => x.Ratings)
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}