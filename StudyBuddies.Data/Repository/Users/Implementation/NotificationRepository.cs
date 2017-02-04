using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Data.Repository.Users.Implementation
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}
