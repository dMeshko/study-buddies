using System.IO;
using StudyBuddies.Domain.Users;

namespace StudyBuddies.Domain.Groups
{
    public class GroupRequest : NotificationEntity
    {
        private User _user;
        private Group _group;
        private RequestStatus _status;

        protected GroupRequest() { }

        public GroupRequest(User user, Group group, RequestStatus requestStatus = RequestStatus.Pending)
        {
            if (user == null)
                throw new InvalidDataException(nameof(user));

            if (group == null)
                throw new InvalidDataException(nameof(group));

            _user = user;
            _group = group;
            _status = requestStatus;
        }

        #region Properties

        public virtual User User => _user;
        public virtual Group Group => _group;

        public virtual RequestStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        #endregion
    }
}
