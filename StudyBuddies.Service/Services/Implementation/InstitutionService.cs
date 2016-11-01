using System;
using StudyBuddies.Data.Infrastructure;
using StudyBuddies.Data.Repository;
using StudyBuddies.Domain.Models;
using StudyBuddies.Service.Infrastructure;
using StudyBuddies.Service.Infrastructure.Exceptions;

namespace StudyBuddies.Service.Services.Implementation
{
    public class InstitutionService : ServiceBase<Institution>, IInstitutionService
    {
        private readonly IInstitutionRepository _institutionRepository;
        private readonly ISubjectRepository _subjectRepository;

        public InstitutionService(IRepository<Institution> institutionRepository, ISubjectRepository subjectRepository) : base(institutionRepository)
        {
            _institutionRepository = (IInstitutionRepository)institutionRepository;
            _subjectRepository = subjectRepository;
        }

        public void CreateSubject(Subject subject)
        {
            if (subject == null)
                throw new BusinessLayerException("Invalid subject!");

            _subjectRepository.Add(subject);
        }

        public void CreateInstitution(Institution institution)
        {
            if (institution == null)
                throw new BusinessLayerException("Invalid institution!");

            _institutionRepository.Add(institution);
        }

        public University GetUniversityById(Guid id)
        {
            University university = _institutionRepository.GetUniversityById(id);
            if (university == null)
                throw new NotFoundException("Invalid university!");

            return university;
        }

        public void CreateUniversity(University university)
        {
            if (university == null)
                throw new BusinessLayerException("Invalid university!");

            _institutionRepository.AddUniversity(university);
        }

        public void RemoveUniversity(University university)
        {
            GetUniversityById(university.Id); // this will check if the university exists
            _institutionRepository.DeleteUniversity(university);
        }
    }
}
