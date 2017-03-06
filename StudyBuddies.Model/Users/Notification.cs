using System;
using System.IO;

namespace StudyBuddies.Domain.Users
{
    public class Notification : BaseEntity
    {
        private User _userFrom;
        private User _userTo;
        private BaseEntity _sourceEntity;
        private DateTime _date;
        private NotificationType _notificationType; // shouldn't it be NotificationDetails?
        private bool _seen;

        protected Notification () { }

        public Notification(User userFrom, User userTo, BaseEntity sourceEntity, NotificationType notificationType)
        {
            if (userFrom == null)
                throw new InvalidDataException(nameof(userFrom));

            if (userTo == null)
                throw new InvalidDataException(nameof(userTo));

            if (sourceEntity == null)
                throw new InvalidDataException(nameof(sourceEntity));

            _userFrom = userFrom;
            _userTo = userTo;
            _sourceEntity = sourceEntity;
            _date = DateTime.UtcNow;
            _notificationType = notificationType;
            _seen = false;
        }

        #region Properties

        public virtual User UserFrom => _userFrom;
        public virtual User UserTo => _userTo;
        public virtual BaseEntity SourceEntity => _sourceEntity;
        public virtual DateTime Date => _date;
        public virtual NotificationType NotificationType => _notificationType;
        public virtual bool Seen { get; set; }

        #endregion
    }
}
