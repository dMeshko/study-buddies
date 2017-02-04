using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddies.Business.ViewModels
{
    public class NotificationViewModel
    {
        public LookupViewModel User { get; set; }
        public IdentityLookupViewModel NotificationType { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }
    }
}
