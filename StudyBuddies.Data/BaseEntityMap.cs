using FluentNHibernate.Mapping;
using StudyBuddies.Domain;

namespace StudyBuddies.Data
{
    public class BaseEntityMap : ClassMap<BaseEntity>
    {
        public BaseEntityMap()
        {
            UseUnionSubclassForInheritanceMapping(); // can't exist on it's own, unite it with it's children.

            Id(x => x.Id)
                .GeneratedBy.GuidComb();
        }
    }
}
