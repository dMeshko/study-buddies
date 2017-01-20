using StudyBuddies.Business.ViewModels.Subjects;

namespace StudyBuddies.Business.Services
{
    public interface ISubjectService
    {
        void CreateGroup(SubjectViewModel model);
    }
}
