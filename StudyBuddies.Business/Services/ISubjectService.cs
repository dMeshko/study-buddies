using System.Collections.Generic;
using StudyBuddies.Business.ViewModels.Subjects;

namespace StudyBuddies.Business.Services
{
    public interface ISubjectService
    {
        IList<SubjectViewModel> GetAllSubjects();
        void CreateSubject(SubjectViewModel model);
    }
}
