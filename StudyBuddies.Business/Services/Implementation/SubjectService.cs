using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using StudyBuddies.Business.Infrastructure.Exceptions;
using StudyBuddies.Business.Infrastructure.Exceptions.Messages;
using StudyBuddies.Business.ViewModels.Subjects;
using StudyBuddies.Data.Repository.Subjects;
using StudyBuddies.Domain.Subjects;

namespace StudyBuddies.Business.Services.Implementation
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

        public IList<SubjectViewModel> GetAllSubjects()
        {
            var subjects = _subjectRepository.GetAll().ToList();
            return Mapper.Map<IList<Subject>, IList<SubjectViewModel>>(subjects);
        }

        public void CreateSubject(SubjectViewModel model)
        {
            var areaOfStudy = _areaOfStudyRepository.GetById(model.AreaOfStudy.Id);
            if (areaOfStudy == null)
                throw new BusinessLayerException(SubjectExceptionMessage.AREA_OF_STUDY_NOT_FOUND);

            var dboSubject = new Subject(model.Name, areaOfStudy);
            _subjectRepository.Add(dboSubject);
        }
    }
}
