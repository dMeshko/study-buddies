namespace StudyBuddies.Domain.Models
{
    public class UserSubject : BaseEntity
    {
        public virtual User User { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual int Grade { get; set; }
        public virtual bool Passed { get; set; }
    }
}
