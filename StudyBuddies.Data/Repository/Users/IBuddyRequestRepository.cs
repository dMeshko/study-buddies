using System;
using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Data.Repository.Users
{
    public interface IBuddyRequestRepository : IRepository<BuddyRequest>
    {
        BuddyRequest GetBuddyRequest(Guid userId, Guid otherUserId);
    }
}
