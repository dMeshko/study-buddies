using System;

namespace StudyBuddies.Domain.Models
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; protected set; }
    }
}