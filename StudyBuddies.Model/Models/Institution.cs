using System.Collections.Generic;

namespace StudyBuddies.Domain.Models
{
    public abstract class Institution : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual IEnumerable<AreaOfStudy> AreasOfStudy { get; set; }
        public virtual IEnumerable<Subject> Subjects { get; set; }
        public virtual IEnumerable<UserAttendsInstitution> UsersAttending { get; set; }
    }
}
