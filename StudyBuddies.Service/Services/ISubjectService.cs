using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyBuddies.Service.ViewModels.Subjects;

namespace StudyBuddies.Service.Services
{
    public interface ISubjectService
    {
        void CreateGroup(SubjectViewModel model);
    }
}
