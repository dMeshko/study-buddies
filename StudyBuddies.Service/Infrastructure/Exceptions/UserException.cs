using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddies.Service.Infrastructure.Exceptions
{
    public class UserException
    {
        public static string USER_NOT_FOUND = "The User couldn't be retreived!";
        public static string BUDDY_REQUEST_INITIATED = "It appears there is already buddy request!";
    }
}
