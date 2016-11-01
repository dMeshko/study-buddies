using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Mappings
{
    public class SubjectMap : ClassMap<Subject>
    {
        public SubjectMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            Map(x => x.Name)
                .Not.Nullable();
        }
    }
}
