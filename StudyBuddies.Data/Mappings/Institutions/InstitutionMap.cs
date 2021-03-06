﻿using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Institutions;

namespace StudyBuddies.Data.Mappings.Institutions
{
    public class InstitutionMap : SubclassMap<Institution>
    {
        public InstitutionMap()
        {
            Abstract();

            Map(x => x.Name)
                .Column("Name")
                .Access.CamelCaseField(Prefix.Underscore)
                .Not.Nullable();

            HasMany(x => x.Locations)
                .KeyColumn("InstitutionId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Cascade.AllDeleteOrphan()
                .Inverse();

            HasMany(x => x.EnrolledStudents)
                .KeyColumn("InstitutionId")
                .Access.CamelCaseField(Prefix.Underscore)
                .Cascade.AllDeleteOrphan()
                .Inverse();
        }
    }
}
