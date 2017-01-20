using System.Collections.Generic;
using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Subjects;

namespace StudyBuddies.Data.Repository.Subjects.Implementation
{
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}
