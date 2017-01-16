namespace StudyBuddies.Domain
{
    public abstract class NotificationEntity : BaseEntity
    {
        private bool _seen;

        public virtual bool Seen
        {
            get { return _seen; }
            set { _seen = value; }
        }
    }
}
