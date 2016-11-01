using System;
using System.Collections.Generic;

namespace StudyBuddies.Domain.Models
{
    public class Group : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual int MaxNumberOfMembers { get; set; }
        public virtual DateTime CreatedOn { get; set; }
        public virtual DateTime ExpireDate { get; set; }
        public virtual User Creator { get; set; }
        public virtual IEnumerable<UserGroup> Members { get; protected set; }
        public virtual Subject Subject { get; set; }
        public virtual IEnumerable<GroupRating> Ratings { get; set; }
    }
}