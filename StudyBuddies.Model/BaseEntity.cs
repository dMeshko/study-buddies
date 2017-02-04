using System;

namespace StudyBuddies.Domain
{
    public abstract class BaseEntity : IComparable<BaseEntity>
    {
        public virtual Guid Id { get; protected set; }

        public virtual int CompareTo(BaseEntity other)
        {
            return Id.CompareTo(other.Id);
        }
    }

    public enum RequestStatus
    {
        Pending = 0,
        Rejected = -1,
        Accepted = 1
    }

    public enum GroupStatus
    {
        Assembly = 0,
        Started = 1,
        Ended = -1
    }

    public enum SubjectStatus
    {
        Current = 0,
        Passed = 1
    }

    public enum InstitutionStatus
    {
        Attending = 0,
        Graduated = 1
    }

    public enum NotificationType
    {
        BuddyRequest = 0,
        BuddyAcceptance = 1,
        Message = 2,
        GroupRequest = 3,
        GroupAcceptance = 4,
        Post = 5,
        Comment = 6
    }
}
