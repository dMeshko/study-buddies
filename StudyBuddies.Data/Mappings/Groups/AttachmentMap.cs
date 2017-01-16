using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Data.Mappings.Groups
{
    public class AttachmentMap : ClassMap<Attachment>
    {
        public AttachmentMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            References(x => x.Post)
                .Column("PostId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Name)
                .Column("Name")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Description)
                .Column("Description")
                .Access.CamelCaseField(Prefix.Underscore)
                .Nullable();

            Map(x => x.File)
                .CustomType<NHibernate.Type.BinaryBlobType>()
                .CustomSqlType("varbinary(MAX)")
                .Nullable()
                .Access.CamelCaseField(Prefix.Underscore)
                .Column("[File]");
        }
    }
}
