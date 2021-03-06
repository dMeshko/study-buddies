﻿using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Data.Mappings.Groups
{
    public class AttachmentMap : SubclassMap<Attachment>
    {
        public AttachmentMap()
        {
            Abstract();

            References(x => x.Post)
                .Column("PostId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.Name)
                .Column("Name")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.ContentType)
                .Column("ContentType")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            Map(x => x.File)
                .CustomType<NHibernate.Type.BinaryBlobType>()
                .CustomSqlType("varbinary(MAX)")
                .Nullable()
                .Access.CamelCaseField(Prefix.Underscore)
                .Column("[File]");
        }
    }
}
