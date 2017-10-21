using FluentNHibernate;
using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Data.Mappings.Users
{
    public class UserMap : SubclassMap<User>
    {
        public UserMap()
        {
            Abstract();

            Map(x => x.Name)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Column("Name")
                .Length(25);

            Map(x => x.Surname)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Column("Surname")
                .Length(35);

            Map(x => x.Email)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Column("Email")
                .Length(50)
                .Unique();

            Map(x => x.Password)
                .Access.CamelCaseField(Prefix.Underscore)
                .Column("Password")
                .Not.Nullable();

            Map(x => x.Username)
                .Access.CamelCaseField(Prefix.Underscore)
                .Nullable()
                .Column("Username")
                .Length(25);

            Map(x => x.CoverImage)
                .CustomType<NHibernate.Type.BinaryBlobType>()
                .CustomSqlType("varbinary(MAX)")
                .Nullable()
                .Access.CamelCaseField(Prefix.Underscore)
                .Column("CoverImage");

            Map(x => x.Image)
                .CustomType<NHibernate.Type.BinaryBlobType>()
                .CustomSqlType("varbinary(MAX)")
                .Nullable()
                .Access.CamelCaseField(Prefix.Underscore)
                .Column("Image");

            Map(x => x.IsActive)
                .Access.CamelCaseField(Prefix.Underscore)
                .Column("IsActive")
                .Not.Nullable();

            HasMany(x => x.CreatedGroups)
                .Access.CamelCaseField(Prefix.Underscore)
                .KeyColumn("AdminId")
                .Inverse()
                .Cascade.AllDeleteOrphan();

            HasMany(x => x.MemberInGroups)
                .Access.CamelCaseField(Prefix.Underscore)
                .KeyColumn("UserId")
                .Inverse()
                .Cascade.AllDeleteOrphan();

            HasMany(x => x.SentBuddyRequests)
                .KeyColumn("UserFromId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Inverse()
                .Cascade.AllDeleteOrphan();

            HasMany(x => x.ReceivedBuddyRequests)
                .KeyColumn("UserToId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Inverse()
                .Cascade.AllDeleteOrphan();

            HasMany<Message>(Reveal.Member<User>("_sentMessages"))
                .KeyColumn("UserFromId")
                .Inverse()
                .Cascade.AllDeleteOrphan();

            HasMany<Message>(Reveal.Member<User>("_receivedMessages"))
                .KeyColumn("UserToId")
                .Inverse()
                .Cascade.AllDeleteOrphan();

            HasMany(x => x.EnrolledSubjects)
                .Access.CamelCaseField(Prefix.Underscore)
                .KeyColumn("UserId")
                .Inverse()
                .Cascade.AllDeleteOrphan();

            HasMany(x => x.EnrolledInstitutions)
                .Access.CamelCaseField(Prefix.Underscore)
                .KeyColumn("UserId")
                .Inverse()
                .Cascade.AllDeleteOrphan();

            HasMany(x => x.Notifications)
                .Access.CamelCaseField(Prefix.Underscore)
                .KeyColumn("UserToId")
                .Inverse()
                .Cascade.AllDeleteOrphan();

            HasManyToMany(x => x.Claims)
                .Access.CamelCaseField(Prefix.Underscore)
                .Cascade.All()
                .ParentKeyColumn("UserId")
                .ChildKeyColumn("ClaimId");
        }
    }
}
