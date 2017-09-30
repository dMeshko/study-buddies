using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Institutions;

namespace StudyBuddies.Data.Mappings.Institutions
{
    public class AcademyMap : SubclassMap<Academy>
    {
        public AcademyMap()
        {
            KeyColumn("InstitutionId");
        }
    }
}
