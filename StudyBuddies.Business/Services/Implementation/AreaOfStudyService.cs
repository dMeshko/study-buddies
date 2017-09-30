using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using StudyBuddies.Business.ViewModels;
using StudyBuddies.Data.Repository.Subjects;
using StudyBuddies.Domain.Subjects;

namespace StudyBuddies.Business.Services.Implementation
{
    public class AreaOfStudyService : IAreaOfStudyService
    {
        private readonly IAreaOfStudyRepository _areaOfStudyRepository;

        public AreaOfStudyService(IAreaOfStudyRepository areaOfStudyRepository)
        {
            _areaOfStudyRepository = areaOfStudyRepository;
        }

        public IEnumerable<LookupViewModel> GetAllAreas()
        {
            var areas = _areaOfStudyRepository.GetAll();
            return Mapper.Map<IEnumerable<AreaOfStudy>, IEnumerable<LookupViewModel>>(areas);
        }
    }
}
