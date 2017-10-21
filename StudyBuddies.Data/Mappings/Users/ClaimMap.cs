﻿using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Data.Mappings.Users
{
    public class ClaimMap : SubclassMap<Claim>
    {
        public ClaimMap()
        {
            Abstract();

            Map(x => x.ClaimType)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Column("ClaimType")
                .Length(25);

            Map(x => x.ClaimValue)
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable()
                .Column("ClaimValue")
                .Length(25);
        }
    }
}
