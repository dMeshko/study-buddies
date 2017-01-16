using System.Linq;
using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Data.Repository.Users.Implementation
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}
