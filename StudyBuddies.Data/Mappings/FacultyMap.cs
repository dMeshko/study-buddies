using FluentNHibernate.Mapping;
using StudyBuddies.Domain.Models;

namespace StudyBuddies.Data.Mappings
{
    public class FacultyMap : SubclassMap<Faculty>
    {
        public FacultyMap()
        {
            /*HasOne(x => x.Location)
                .Cascade.All();*/

            Component(x => x.Location);

            References(x => x.University)
                .Cascade.All();
        }
    }
}
