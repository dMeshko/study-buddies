using System.Collections.Generic;

namespace StudyBuddies.Domain.Models
{
    public class Academy : Institution
    {
        public virtual IEnumerable<Location> Locations { get; set; }
    }
}
