using System;

namespace StudyBuddies.Domain.Models
{
    public class Message : BaseEntity
    {
        public virtual User UserFrom { get; set; }
        public virtual User UserTo { get; set; }
        public virtual string Content { get; set; }
        public virtual DateTime Date { get; set; }
    }
}
