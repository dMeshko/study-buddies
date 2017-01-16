using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Groups;

namespace StudyBuddies.Data.Repository.Groups.Implementation
{
    public class AttachmentRepository : RepositoryBase<Attachment>, IAttachmentRepository
    {
        public AttachmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}
