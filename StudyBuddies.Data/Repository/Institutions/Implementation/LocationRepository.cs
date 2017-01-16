using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Domain.Institutions;

namespace StudyBuddies.Data.Repository.Institutions.Implementation
{
    public class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}
