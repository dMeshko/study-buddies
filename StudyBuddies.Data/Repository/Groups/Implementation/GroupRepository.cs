using System.Collections.Generic;
using System.Linq;
using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Data.Repository.Groups.Implementation
{
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public IEnumerable<Group> GetGroupsByName(string name)
        {
            return GetMany(x => x.Name.Contains(name))
                .ToList();
        }
    }
}
