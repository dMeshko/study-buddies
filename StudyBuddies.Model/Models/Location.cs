namespace StudyBuddies.Domain.Models
{
    public class Location : BaseEntity
    {
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }
    }
}
