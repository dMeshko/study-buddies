using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Data.Repository.Users.Implementation
{
    public class MessageRepository : RepositoryBase<Message>, IMessageRepository
    {
        public MessageRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}
