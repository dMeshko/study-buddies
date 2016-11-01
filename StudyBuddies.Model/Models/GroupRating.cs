using System;

namespace StudyBuddies.Domain.Models
{
    public class GroupRating : BaseEntity
    {
        public virtual User UserFrom { get; set; }
        public virtual User UserTo { get; set; }
        public virtual Group Group { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual int Grade { get; set; }
    }
}
