using System;
using System.IO;

namespace StudyBuddies.Domain.Users
{
    public class BuddyRequest : NotificationEntity
    {
        private User _userFrom;
        private User _userTo;
        private DateTime _date;
        private RequestStatus _status;

        protected BuddyRequest() { }

        public BuddyRequest(User userFrom, User userTo, RequestStatus requestStatus = RequestStatus.Pending)
        {
            if (userFrom == null)
                throw new InvalidDataException(nameof(userFrom));

            if (userTo == null)
                throw new InvalidDataException(nameof(userTo));

            _userFrom = userFrom;
            _userTo = userTo;
            _date = DateTime.UtcNow;
            _status = requestStatus;
        }

        #region Properties

        public virtual User UserFrom => _userFrom;
        public virtual User UserTo => _userTo;
        public virtual DateTime Date => _date;
        public virtual RequestStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        #endregion
    }
}
