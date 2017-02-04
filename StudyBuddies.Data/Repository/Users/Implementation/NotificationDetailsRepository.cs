using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Data.Repository.Users.Implementation
{
    class NotificationDetailsRepository : RepositoryBase<NotificationDetails>, INotificationDetailsRepository
    {
        public NotificationDetailsRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}
