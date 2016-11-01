using System;

namespace StudyBuddies.Domain.Models
{
    public class UserAttendsInstitution : BaseEntity
    {
        public virtual User User { get; set; }
        public virtual Institution Institution { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
    }
}
