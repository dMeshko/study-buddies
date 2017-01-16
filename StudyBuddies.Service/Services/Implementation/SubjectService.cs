using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyBuddies.Data.Repository;
using StudyBuddies.Data.Repository.Subjects;
using StudyBuddies.Domain.Subjects;
using StudyBuddies.Service.Infrastructure.Exceptions;
using StudyBuddies.Service.ViewModels.Subjects;

namespace StudyBuddies.Service.Services.Implementation
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IAreaOfStudyRepository _areaOfStudyRepository;

        public SubjectService(ISubjectRepository subjectRepository, IAreaOfStudyRepository areaOfStudyRepository)
        {
            _subjectRepository = subjectRepository;
            _areaOfStudyRepository = areaOfStudyRepository;
        }

        public void CreateGroup(SubjectViewModel model)
        {
            var areaOfStudy = _areaOfStudyRepository.GetById(model.AreaOfStudy.Id);
            if (areaOfStudy == null)
                throw new BusinessLayerException(SubjectException.AREA_OF_STUDY_NOT_FOUND);

            var dboSubject = new Subject(model.Name, areaOfStudy);
            _subjectRepository.Add(dboSubject);
        }
    }
}
