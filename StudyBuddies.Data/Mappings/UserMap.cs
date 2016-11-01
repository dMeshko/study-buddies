using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            Map(x => x.Name)
                .Length(25)
                .Not.Nullable();

            Map(x => x.Surname)
                .Length(35)
                .Not.Nullable();

            Map(x => x.Email) //add the pattern
                .Unique()
                .Length(50);

            Map(x => x.Username)
                .Length(20)
                .Unique();

            Map(x => x.Password) //encrypt the password
                .Length(50);

            Map(x => x.Image)
                .CustomType<NHibernate.Type.BinaryBlobType>()
                .Nullable();

            HasMany(x => x.CreatedGroups)
                .Inverse() //the updates should be done via the Group object
                .Cascade.AllDeleteOrphan();

            HasMany(x => x.MemberInGroups)
                .Inverse()
                .Cascade.All();

            HasMany(x => x.SentFriendRequests)
                .Inverse()
                .KeyColumn("UserFrom_id")
                .Cascade.AllDeleteOrphan();

            HasMany(x => x.ReceivedFriendRequests)
                .Inverse()
                .KeyColumn("UserTo_id")
                .Cascade.AllDeleteOrphan();

            HasMany(x => x.SentMessages)
                .Inverse()
                //.Not.LazyLoad()
                .KeyColumn("UserFrom_id")
                .Cascade.AllDeleteOrphan();

            HasMany(x => x.ReceivedMessages)
                .Inverse()
                //.Not.LazyLoad()
                .KeyColumn("UserTo_id")
                .Cascade.AllDeleteOrphan();

            HasMany(x => x.Subjects)
                .Inverse()
                .Cascade.AllDeleteOrphan();

            //handle enrolled subjects here

            HasMany(x => x.AttendsTo)
                .Inverse()
                .Cascade.AllDeleteOrphan();
        }
    }
}