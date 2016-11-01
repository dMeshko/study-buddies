using System.Collections.Generic;

namespace StudyBuddies.Domain.Models
{
    public class User : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual byte?[] Image { get; set; }
        public virtual IEnumerable<Group> CreatedGroups
        {
            get; protected set;
        }
        public virtual IEnumerable<UserGroup> MemberInGroups { get; set; }
        public virtual IEnumerable<Friendship> SentFriendRequests { get; set; }
        public virtual IEnumerable<Friendship> ReceivedFriendRequests { get; set; }
        public virtual IEnumerable<Message> SentMessages { get; set; }
        public virtual IEnumerable<Message> ReceivedMessages { get; set; }
        public virtual IEnumerable<UserSubject> Subjects { get; set; }
        public virtual IEnumerable<UserAttendsInstitution> AttendsTo { get; set; } 
    }
}