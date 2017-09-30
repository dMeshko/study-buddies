using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyBuddies.Business.ViewModels;

namespace StudyBuddies.Business.Services
{
    public interface IAreaOfStudyService
    {
        IEnumerable<LookupViewModel> GetAllAreas();
    }
}
