using System;
using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Data.Repository.Users.Implementation
{
    public class BuddyRequestRepository : RepositoryBase<BuddyRequest>, IBuddyRequestRepository
    {
        public BuddyRequestRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public BuddyRequest GetBuddyRequest(Guid userId, Guid otherUserId)
        {
            return Get(x => (x.UserFrom.Id == userId && x.UserTo.Id == otherUserId) || (x.UserFrom.Id == otherUserId && x.UserTo.Id == userId));
        }
    }
}
