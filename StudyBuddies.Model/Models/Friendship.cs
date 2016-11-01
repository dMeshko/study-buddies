using System;

namespace StudyBuddies.Domain.Models
{
    public class Friendship : BaseEntity
    {
        public virtual User UserFrom { get; set; }
        public virtual User UserTo { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual bool Status { get; set; } //this is not enough the describe the 3 states of friendship, {pending, accepted, rejected}
        public virtual  bool Seen { get; set; } //true
    }
}
