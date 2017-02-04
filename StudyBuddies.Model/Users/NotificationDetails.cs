using System.IO;

namespace StudyBuddies.Domain.Users
{
    public class NotificationDetails : BaseEntity
    {
        private NotificationType _notificationType;
        private string _notificationMeta;

        protected NotificationDetails() { }

        public NotificationDetails(NotificationType notificationType, string notificationMeta)
        {
            if (notificationMeta == null || notificationMeta.Trim().Length == 0)
                throw new InvalidDataException(nameof(notificationMeta));

            _notificationType = notificationType;
            _notificationMeta = notificationMeta;
        }

        #region Properties

        public virtual NotificationType NotificationType => _notificationType;

        public virtual string NotificationMeta => _notificationMeta;

        #endregion
    }
}
