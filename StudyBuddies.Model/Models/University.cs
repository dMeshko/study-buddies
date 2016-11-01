using System.Collections.Generic;

namespace StudyBuddies.Domain.Models
{
    public class University : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual Location Location { get; set; }
        public virtual IEnumerable<Faculty> Faculties { get; set; }
    }
}
