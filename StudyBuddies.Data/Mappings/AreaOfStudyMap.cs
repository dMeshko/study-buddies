using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Mappings
{
    public class AreaOfStudyMap : ClassMap<AreaOfStudy>
    {
        public AreaOfStudyMap()
        {
            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            Map(x => x.Name)
                .Unique()
                .Not.Nullable();
        }
    }
}
